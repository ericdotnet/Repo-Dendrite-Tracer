using BitMiracle.LibTiff.Classic;
using RasterSharp;
using System.Drawing;

namespace DendriteTracer.Core;

public class RoiCollection
{
    public int FrameCount { get; }
    public Roi[] Rois { get; }
    public int RoiCount => Rois.Length;

    // TODO: replace 2d arrays with RoiData objects?
    public RasterSharp.Channel[,] GreenImages { get; }
    public RasterSharp.Channel[,] RedImages { get; }
    public Bitmap[,] MergedImages { get; }
    public double[,][] SortedRedPixels { get; }
    public double[,] NoiseFloors { get; }
    public double[,] Thresholds { get; }
    public Bitmap[,] MaskImages { get; }

    public RoiCollection(RoiGenerator roiGen)
    {
        FrameCount = roiGen.FrameCount;
        Rois = roiGen.Tracing.GetEvenlySpacedRois();
        RedImages = Crop(roiGen.RedImages, Rois);
        GreenImages = Crop(roiGen.GreenImages, Rois);
        MergedImages = GetMergedImages(RedImages, GreenImages);
        SortedRedPixels = GetSortedPixels(RedImages);
        NoiseFloors = GetNoiseFloors(SortedRedPixels, 50);
        Thresholds = GetThresholds(NoiseFloors, 3);
        MaskImages = GetMaskImages(RedImages, Thresholds, roiGen.Tracing.IsCircular);
    }

    private static Bitmap[,] GetMaskImages(Channel[,] images, double[,] thresholds, bool isCircular)
    {
        int frameCount = images.GetLength(0);
        int roiCount = images.GetLength(1);

        Bitmap[,] masks = new Bitmap[frameCount, roiCount];

        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < roiCount; j++)
            {
                masks[i, j] = GetMaskImage(images[i, j], thresholds[i, j], isCircular);
            }
        }

        return masks;
    }

    private static Bitmap GetMaskImage(Channel source, double threshold, bool isCircular)
    {
        RasterSharp.Image img = new(source.Width, source.Height);

        for (int y = 0; y < img.Height; y++)
        {
            for (int x = 0; x < img.Width; x++)
            {
                bool isAboveThreshold = source.GetValue(x, y) >= threshold;
                bool isOutsideCircle = false;

                if (isCircular)
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

        return img.ToSDBitmap();
    }

    private static double[,] GetThresholds(double[,] floors, double mult)
    {
        int frameCount = floors.GetLength(0);
        int roiCount = floors.GetLength(1);

        double[,] thresholds = new double[frameCount, roiCount];

        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < roiCount; j++)
            {
                thresholds[i, j] = floors[i, j] * mult;
            }
        }

        return thresholds;
    }

    private static double[,] GetNoiseFloors(double[,][] SortedRedPixels, double percentile)
    {
        int frameCount = SortedRedPixels.GetLength(0);
        int roiCount = SortedRedPixels.GetLength(1);

        double[,] floors = new double[frameCount, roiCount];

        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < roiCount; j++)
            {
                double[] values = SortedRedPixels[i, j];
                int index = (int)(values.Length * percentile / 100.0);
                floors[i, j] = values[index];
            }
        }

        return floors;
    }

    private static double[,][] GetSortedPixels(RasterSharp.Channel[,] imgs)
    {
        int frameCount = imgs.GetLength(0);
        int roiCount = imgs.GetLength(1);
        int pixelsPerRoi = frameCount * roiCount;

        double[,][] pixels = new double[frameCount, roiCount][];

        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < roiCount; j++)
            {
                pixels[i, j] = imgs[i, j].GetValues().OrderBy(x => x).ToArray();
            }
        }

        return pixels;
    }

    private static Bitmap[,] GetMergedImages(RasterSharp.Channel[,] RedImages, RasterSharp.Channel[,] GreenImages)
    {
        int frameCount = RedImages.GetLength(0);
        int roiCount = RedImages.GetLength(1);

        Bitmap[,] merged = new Bitmap[frameCount, roiCount];

        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < roiCount; j++)
            {
                RasterSharp.Channel r = RedImages[i, j].Clone();
                RasterSharp.Channel g = GreenImages[i, j].Clone();

                r.Rescale();
                g.Rescale();

                RasterSharp.Image img = new(r, g, r);

                merged[i, j] = img.ToSDBitmap();
            }
        }

        return merged;
    }

    /// <summary>
    /// Return a 2D array containing the crop of every ROI for every frame
    /// </summary>
    private static RasterSharp.Channel[,] Crop(RasterSharp.Channel[] imgs, Roi[] rois)
    {
        int frameCount = imgs.Length;
        int roiCount = rois.Length;

        RasterSharp.Channel[,] cropped = new RasterSharp.Channel[frameCount, roiCount];

        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < roiCount; j++)
            {
                cropped[i, j] = Crop(imgs[i], rois[j]);
            }
        }

        return cropped;
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
}
