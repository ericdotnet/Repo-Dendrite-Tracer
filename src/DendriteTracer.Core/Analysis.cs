using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DendriteTracer.Core;

public class Analysis
{
    public AnalysisSettings Settings { get; set; }
    public MaxProjectionSeries Proj { get; }
    RasterSharp.Channel[] RedImages { get; }
    RasterSharp.Channel[] GreenImages { get; }
    //public Bitmap[] FrameImages { get; }
    public int FrameCount => RedImages.Length;
    public Tracing Tracing { get; }
    public int RoiCount => Tracing.Count;
    public int SelectedFrame { get; set; }
    public int SelectedRoi { get; set; }
    public string SelectedRoiTitle => $"ROI {SelectedRoi + 1} of {RoiCount}";
    public string SelectedFrameTitle => $"{Path.GetFileName(Settings.TifFilePath)} (Frame {SelectedFrame + 1} of {FrameCount})";

    public Analysis(AnalysisSettings settings)
    {
        Settings = settings;
        Proj = new(settings.TifFilePath);
        //FrameImages = GetFrameImages();
        Tracing = new(Proj.Width, Proj.Height);
        (RedImages, GreenImages) = Proj.GetAllChannels();
        //ApplyImageFloorSubtraction(); // TODO:
    }

    private void ApplyImageFloorSubtraction()
    {
        if (Settings.ImageSubtractionFloor_Percent == 0)
            return;

        for (int i = 0; i < FrameCount; i++)
        {
            ApplySubtraction(RedImages[i], Settings.ImageSubtractionFloor_Percent);
            ApplySubtraction(GreenImages[i], Settings.ImageSubtractionFloor_Percent);
        }
    }

    private void ApplySubtraction(RasterSharp.Channel image, double percent)
    {
        double[] sorted = image.GetValues().OrderBy(x => x).ToArray();
        int index = (int)(percent / 100 * sorted.Length);
        double floor = sorted[index];

        System.Diagnostics.Debug.WriteLine($"SUBTRACTING {floor}");

        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                double value = image.GetValue(x, y);
                value -= floor;
                image.SetValue(x, y, value);
            }
        }
    }

    private Bitmap[] GetFrameImages()
    {
        Bitmap[] images = new Bitmap[Proj.Length];

        for (int i = 0; i < Proj.Length; i++)
        {
            images[i] = GetFrameImage(i);
        }

        return images;
    }

    private Bitmap GetFrameImage(int frame)
    {
        byte[] bytes = Proj.GetPreviewImageBytes(frame, Settings.Brightness);
        using MemoryStream ms = new(bytes);
        Bitmap bmp = new(ms);
        return bmp;
    }

    public RoiCollectionData GetRoiData(int frameIndex)
    {
        ImageWithTracing iwt = new(
            tracing: Tracing,
            spacing: Settings.RoiSpacing_Pixels,
            radius: Settings.RoiRadius_Pixels,
            red: RedImages[frameIndex],
            green: GreenImages[frameIndex]);

        return new(iwt);
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
