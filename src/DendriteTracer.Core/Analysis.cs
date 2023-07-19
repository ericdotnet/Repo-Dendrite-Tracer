using System.Drawing;

namespace DendriteTracer.Core;

public class Analysis
{
    public AnalysisSettings Settings { get; set; }
    public MaxProjectionSeries Proj { get; }
    RasterSharp.Channel[] FrameImagesRed { get; }
    RasterSharp.Channel[] FrameImagesGreen { get; }
    public int FrameCount => FrameImagesRed.Length;
    public Tracing Tracing { get; }
    public string[] RoiNames => Enumerable.Range(0, RoiCount).Select(x => $"ROI #{x}").ToArray();
    public int SelectedFrame { get; set; }
    public int SelectedRoi { get; set; }
    public string SelectedRoiTitle => $"ROI {SelectedRoi + 1} of {RoiCount}";
    public string SelectedFrameTitle => $"{Path.GetFileName(Settings.TifFilePath)} (Frame {SelectedFrame + 1} of {FrameCount})";
    public Roi[] Rois { get; }
    public int RoiCount => Rois.Length;
    public RasterSharp.Channel[,] RoiImagesRed { get; }
    public RasterSharp.Channel[,] RoiImagesGreen { get; }
    public RasterSharp.Image[,] RoiImagesMerge { get; }
    public double[,] RoiNoiseFloors { get; }
    public double[,] RoiThresholds { get; }
    public RasterSharp.Image[,] RoiMaskImages { get; }
    public double[,] RoiMeansRed { get; }
    public double[,] RoiMeansGreen { get; }
    public double[,] RoiRatios { get; }
    public double[] RoiPositions => Enumerable.Range(0, RoiCount).Select(x => x * Settings.RoiSpacing_Microns).ToArray();

    public Analysis(AnalysisSettings settings)
    {
        Settings = settings;
        Proj = new(settings.TifFilePath);
        Tracing = new(Proj.Width, Proj.Height, 1);
        (FrameImagesRed, FrameImagesGreen) = Proj.GetAllChannels();
        Rois = Tracing.GetEvenlySpacedRois(settings.RoiSpacing_Pixels, settings.RoiRadius_Pixels);
        System.Diagnostics.Debug.WriteLine($"ROI COUNT: {Rois.Length}");
        RoiImagesRed = GetRoiImages(FrameImagesRed, Rois);
        RoiImagesGreen = GetRoiImages(FrameImagesGreen, Rois);
        RoiImagesMerge = GetMergedRoiImages(RoiImagesRed, RoiImagesGreen);
        (RoiNoiseFloors, RoiThresholds) = CalculateThresholds(RoiImagesRed);
        RoiMaskImages = GetMaskImages(RoiImagesRed);
        RoiMeansRed = GetRoiMeans(RoiImagesRed, RoiThresholds);
        RoiMeansGreen = GetRoiMeans(RoiImagesGreen, RoiThresholds);
        RoiRatios = GetRoiRatios(RoiMeansRed, RoiMeansGreen);
    }

    public RasterSharp.Image[,] GetMergedRoiImages(RasterSharp.Channel[,] reds, RasterSharp.Channel[,] greens)
    {
        RasterSharp.Image[,] img = new RasterSharp.Image[reds.GetLength(0), reds.GetLength(1)];

        for (int i = 0; i < reds.GetLength(0); i++)
        {
            for (int j = 0; j < reds.GetLength(1); j++)
            {
                img[i, j] = new(reds[i, j], greens[i, j], reds[i, j]);
            }
        }

        return img;
    }

    public (double[] position, double[] red, double[] green, double[] ratio) GetRoiCurvesForFrame(int frameIndex)
    {
        double[] red = new double[RoiCount];
        double[] green = new double[RoiCount];
        double[] ratio = new double[RoiCount];

        for (int i = 0; i < RoiCount; i++)
        {
            red[i] = RoiMeansRed[frameIndex, i];
            green[i] = RoiMeansGreen[frameIndex, i];
            ratio[i] = RoiRatios[frameIndex, i];
        }

        return (RoiPositions, red, green, ratio);
    }

    public double[,] GetRoiRatios(double[,] redMeans, double[,] greenMeans)
    {
        double[,] means = new double[redMeans.GetLength(0), redMeans.GetLength(1)];

        for (int i = 0; i < redMeans.GetLength(0); i++)
        {
            for (int j = 0; j < redMeans.GetLength(1); j++)
            {
                means[i, j] = greenMeans[i, j] / redMeans[i, j];
            }
        }

        return means;
    }

    public double[,] GetRoiMeans(RasterSharp.Channel[,] images, double[,] thresholds)
    {
        double[,] means = new double[images.GetLength(0), images.GetLength(1)];

        for (int i = 0; i < images.GetLength(0); i++)
        {
            for (int j = 0; j < images.GetLength(1); j++)
            {
                var values = images[i, j].GetValues().Where(x => x > thresholds[i, j]);
                means[i, j] = values.Sum() / values.Count();
            }
        }

        return means;
    }

    public RasterSharp.Image[,] GetMaskImages(RasterSharp.Channel[,] images)
    {
        RasterSharp.Image[,] masks = new RasterSharp.Image[images.GetLength(0), images.GetLength(1)];

        for (int i = 0; i < images.GetLength(0); i++)
        {
            for (int j = 0; j < images.GetLength(1); j++)
            {
                masks[i, j] = GetThresholdImage(images[i, j], RoiThresholds[i, j]);
            }
        }

        return masks;
    }

    public RasterSharp.Image GetThresholdImage(RasterSharp.Channel source, double threshold)
    {
        RasterSharp.Image img = new(source.Width, source.Height);

        for (int y = 0; y < img.Height; y++)
        {
            for (int x = 0; x < img.Width; x++)
            {
                bool isAboveThreshold = source.GetValue(x, y) >= threshold;
                bool isOutsideCircle = false;

                if (Settings.RoiIsCircular)
                {
                    double radius = (double)source.Width / 2;
                    double dX = Math.Abs(radius - x);
                    double dY = Math.Abs(radius - y);
                    double distanceFromCenter = Math.Sqrt(dX * dX + dY * dY);
                    isOutsideCircle = distanceFromCenter > radius;
                }

                if (isOutsideCircle)
                {
                    img.Red.SetValue(x, y, 0);
                    img.Green.SetValue(x, y, 0);
                    img.Blue.SetValue(x, y, 0);
                }
                else if (isAboveThreshold)
                {
                    img.Red.SetValue(x, y, 255);
                    img.Green.SetValue(x, y, 0);
                    img.Blue.SetValue(x, y, 0);
                }
                else
                {
                    img.Red.SetValue(x, y, 0);
                    img.Green.SetValue(x, y, 0);
                    img.Blue.SetValue(x, y, 255);
                }
            }
        }

        return img;
    }

    public (double[,] floors, double[,] thresholds) CalculateThresholds(RasterSharp.Channel[,] images)
    {
        double[,] floors = new double[images.GetLength(0), images.GetLength(1)];
        double[,] thresholds = new double[images.GetLength(0), images.GetLength(1)];

        for (int i = 0; i < images.GetLength(0); i++)
        {
            for (int j = 0; j < images.GetLength(1); j++)
            {
                double[] sorted = images[i, j].GetValues().OrderBy(x => x).ToArray();
                int floorIndex = (int)(Settings.PixelThresholdFloor_Percent * sorted.Length / 100.0);
                double floor = sorted[floorIndex];
                double threshold = floor * Settings.PixelThreshold_Multiple;

                floors[i, j] = floor;
                thresholds[i, j] = threshold;
            }
        }

        return (floors, thresholds);
    }

    private static RasterSharp.Channel[,] GetRoiImages(RasterSharp.Channel[] frameImages, Roi[] rois)
    {
        RasterSharp.Channel[,] images = new RasterSharp.Channel[frameImages.Length, rois.Length];

        for (int frameIndex = 0; frameIndex < frameImages.Length; frameIndex++)
        {
            for (int roiIndex = 0; roiIndex < rois.Length; roiIndex++)
            {
                images[frameIndex, roiIndex] = Crop(frameImages[frameIndex], rois[roiIndex]);
            }
        }

        return images;
    }

    private static RasterSharp.Channel Crop(RasterSharp.Channel img, Roi roi)
    {
        return Crop(img, (int)roi.Left, (int)roi.Top, (int)roi.Width, (int)roi.Height);
    }

    private static RasterSharp.Channel Crop(RasterSharp.Channel img, int x, int y, int width, int height)
    {
        RasterSharp.Channel img2 = new(width, height);

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                img2.SetValue(col, row, img.GetValue(col + x, row + y));
            }
        }

        return img2;
    }

    private Bitmap GetFrameImage(int frame)
    {
        byte[] bytes = Proj.GetPreviewImageBytes(frame, Settings.Brightness);
        using MemoryStream ms = new(bytes);
        Bitmap bmp = new(ms);
        return bmp;
    }

    public Bitmap GetAnnotatedFrame()
    {
        Bitmap bmp = GetFrameImage(SelectedFrame);

        // TODO: replace with RasterSharp drawing
        using Graphics gfx = Graphics.FromImage(bmp);
        gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        PointF[] points = Tracing.GetPixels().Select(px => new PointF(px.X, px.Y)).ToArray();

        if (points.Length > 1)
        {
            gfx.DrawLines(Pens.Yellow, points);
        }

        foreach (PointF pt in points)
        {
            int r = 2;
            RectangleF rect = new(pt.X - r, pt.Y - r, r * 2, r * 2);
            gfx.DrawRectangle(Pens.Yellow, rect.X, rect.Y, rect.Width, rect.Height);
        }

        RectangleF[] roiRects = Tracing.GetEvenlySpacedRois(Settings.RoiSpacing_Pixels, Settings.RoiRadius_Pixels)
            .Select(roi => new RectangleF(roi.Left, roi.Top, roi.Width, roi.Height))
            .ToArray();

        foreach (RectangleF rect in roiRects)
        {
            if (Settings.RoiIsCircular)
            {
                gfx.DrawEllipse(Pens.Cyan, rect.X, rect.Y, rect.Width, rect.Height);
            }
            else
            {
                gfx.DrawRectangle(Pens.Cyan, rect.X, rect.Y, rect.Width, rect.Height);
            }
        }

        return bmp;
    }
}
