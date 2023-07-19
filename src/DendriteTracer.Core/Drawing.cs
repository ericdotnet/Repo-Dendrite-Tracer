using System.Drawing;

namespace DendriteTracer.Core;

public static class Drawing
{
    public static Bitmap DrawTracingAndRois(Bitmap source, Tracing Tracing, bool showSpines, bool showRois)
    {
        // TODO: replace with RasterSharp drawing
        Bitmap bmp = new(source);
        using Graphics gfx = Graphics.FromImage(bmp);
        gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        if (showSpines)
            DrawSpines(gfx, Tracing.GetPixels());

        if (showRois)
            DrawRois(gfx, Tracing.GetEvenlySpacedRois(), Tracing.IsCircular);

        return bmp;
    }

    private static void DrawSpines(Graphics gfx, PixelLocation[] pixels)
    {
        PointF[] points = pixels.Select(px => new PointF(px.X, px.Y)).ToArray();

        if (points.Length > 1)
        {
            using Pen pen = new(Color.FromArgb(150, Color.Yellow));
            gfx.DrawLines(pen, points);
        }

        foreach (PointF pt in points)
        {
            int r = 2;
            RectangleF rect = new(pt.X - r, pt.Y - r, r * 2, r * 2);
            gfx.DrawRectangle(Pens.Yellow, rect.X, rect.Y, rect.Width, rect.Height);
        }
    }

    private static void DrawRois(Graphics gfx, Roi[] rois, bool isCircular)
    {
        RectangleF[] roiRects = rois.Select(roi => new RectangleF(roi.Left, roi.Top, roi.Width, roi.Height)).ToArray();

        using Pen pen = new(Color.FromArgb(150, Color.Cyan));

        foreach (RectangleF rect in roiRects)
        {

            if (isCircular)
            {
                gfx.DrawEllipse(pen, rect.X, rect.Y, rect.Width, rect.Height);
            }
            else
            {
                gfx.DrawRectangle(Pens.Cyan, rect.X, rect.Y, rect.Width, rect.Height);
            }
        }
    }
}
