using System.Drawing;
using System.Numerics;

namespace DendriteTracer.Core;

public static class Drawing
{
    public static (Bitmap[,], bool[,][,]) GetMaskImages(RasterSharp.Channel[,] images, double[] thresholds, bool isCircular, bool maskDisabled)
    {
        int frameCount = images.GetLength(0);
        int roiCount = images.GetLength(1);

        Bitmap[,] maskImages = new Bitmap[frameCount, roiCount];
        bool[,][,] mask = new bool[frameCount, roiCount][,];

        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < roiCount; j++)
            {
                (maskImages[i, j], mask[i, j]) = GetMask(images[i, j], thresholds[i], isCircular, maskDisabled);
            }
        }

        return (maskImages, mask);
    }

    public static (Bitmap image, bool[,] mask) GetMask(RasterSharp.Channel source, double threshold, bool isCircular, bool maskDisabled)
    {
        RasterSharp.Image img = new(source.Width, source.Height);

        bool[,] mask = new bool[source.Height, source.Width];

        for (int y = 0; y < img.Height; y++)
        {
            for (int x = 0; x < img.Width; x++)
            {
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
                    mask[y, x] = false;
                    continue;
                }

                bool isAboveThreshold = maskDisabled ? true : source.GetValue(x, y) >= threshold;

                if (isAboveThreshold)
                {
                    img.Red.SetValue(x, y, 255);
                    img.Green.SetValue(x, y, 0);
                    img.Blue.SetValue(x, y, 0);
                    mask[y, x] = true;
                }
                else
                {
                    img.Red.SetValue(x, y, 0);
                    img.Green.SetValue(x, y, 0);
                    img.Blue.SetValue(x, y, 255);
                    mask[y, x] = false;
                }
            }
        }

        return (img.ToSDBitmap(), mask);
    }

    public static Bitmap[,] GetMergedImages(RasterSharp.Channel[,] RedImages, RasterSharp.Channel[,] GreenImages, bool isCircular, double brightness)
    {
        int frameCount = RedImages.GetLength(0);
        int roiCount = RedImages.GetLength(1);

        Bitmap[,] merged = new Bitmap[frameCount, roiCount];

        if (RedImages.GetLength(0) == 0 || RedImages.GetLength(1) == 0)
            return merged;

        double mult = GetBestMultiplier(RedImages[0, 0]);

        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < roiCount; j++)
            {
                RasterSharp.Channel r = RedImages[i, j].Clone();
                RasterSharp.Channel g = GreenImages[i, j].Clone();

                if (isCircular)
                {
                    ApplyCircularMask(r);
                    ApplyCircularMask(g);
                }

                Multiply(r, mult * brightness);
                Multiply(g, mult * brightness);

                RasterSharp.Image img = new(r, g, r);

                merged[i, j] = img.ToSDBitmap();
            }
        }

        return merged;
    }

    public static double GetBestMultiplier(RasterSharp.Channel ch)
    {
        double max = ch.GetValues().Max();

        double mult = 1;

        while (max / mult > 255)
        {
            mult *= 2;
        }

        return 1.0 / (mult / 2);
    }

    public static void ApplyCircularMask(RasterSharp.Channel ch)
    {
        double radius = (double)ch.Width / 2;

        for (int y = 0; y < ch.Height; y++)
        {
            for (int x = 0; x < ch.Width; x++)
            {
                double dX = Math.Abs(radius - x);
                double dY = Math.Abs(radius - y);
                double distanceFromCenter = Math.Sqrt(dX * dX + dY * dY);
                bool isOutsideCircle = distanceFromCenter > radius;

                if (isOutsideCircle)
                {
                    ch.SetValue(x, y, 0);
                }
            }
        }
    }

    public static Bitmap DrawTracingAndRois(Bitmap source, Tracing Tracing, bool showSpines, bool showRois, int selectedRoi)
    {
        // TODO: replace with RasterSharp drawing
        Bitmap bmp = new(source);
        using Graphics gfx = Graphics.FromImage(bmp);
        gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        if (showSpines)
            DrawSpines(gfx, Tracing.GetPixels());

        if (showRois)
            DrawRois(gfx, Tracing.GetEvenlySpacedRois(), Tracing.IsCircular, selectedRoi);

        return bmp;
    }

    public static void DrawSpines(Graphics gfx, PixelLocation[] pixels)
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

    public static void DrawRois(Graphics gfx, Roi[] rois, bool isCircular, int selectedRoi)
    {
        RectangleF[] roiRects = rois.Select(roi => new RectangleF(roi.Left, roi.Top, roi.Width, roi.Height)).ToArray();

        using Pen penNormal = new(Color.FromArgb(100, Color.Cyan));
        using Pen penSelected = new(Color.Cyan, 2);

        for (int i = 0; i < roiRects.Length; i++)
        {
            RectangleF rect = roiRects[i];

            if (isCircular)
            {
                gfx.DrawEllipse(i == selectedRoi ? penSelected : penNormal, rect.X, rect.Y, rect.Width, rect.Height);
            }
            else
            {
                gfx.DrawRectangle(i == selectedRoi ? penSelected : penNormal, rect.X, rect.Y, rect.Width, rect.Height);
            }
        }
    }


    /// <summary>
    /// Return a 2D array containing the crop of every ROI for every frame
    /// </summary>
    public static RasterSharp.Channel[,] Crop(RasterSharp.Channel[] imgs, Roi[] rois)
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

    public static RasterSharp.Channel Crop(RasterSharp.Channel img, Roi roi)
    {
        return Crop(img, (int)roi.Left, (int)roi.Top, (int)roi.Width, (int)roi.Height);
    }

    public static RasterSharp.Channel Crop(RasterSharp.Channel img, int x, int y, int width, int height)
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

    public static void AssertValidTif(SciTIF.TifFile tif)
    {
        if (tif.Frames < 2)
        {
            throw new InvalidOperationException("Projection TIF file must contain multiple frames");
        }

        if (tif.Channels != 2)
        {
            throw new InvalidOperationException("Projection TIF file must have 2 channels");
        }

        if (tif.Slices != 1)
        {
            throw new InvalidOperationException("Projection TIF file must have only 1 slice");
        }
    }

    public static (RasterSharp.Channel red, RasterSharp.Channel green) GetChannels(SciTIF.TifFile tif, int frame)
    {
        SciTIF.Image red = tif.GetImage(frame, 0, 0);
        SciTIF.Image green = tif.GetImage(frame, 0, 1);

        RasterSharp.Channel redChannel = new(red.Width, red.Height, red.Values);
        RasterSharp.Channel greenChannel = new(green.Width, green.Height, green.Values);

        return (redChannel.Clone(), greenChannel.Clone());
    }

    public static (RasterSharp.Channel[] reds, RasterSharp.Channel[] greens) GetAllChannels(SciTIF.TifFile tif)
    {
        RasterSharp.Channel[] reds = new RasterSharp.Channel[tif.Frames];
        RasterSharp.Channel[] greens = new RasterSharp.Channel[tif.Frames];

        for (int i = 0; i < tif.Frames; i++)
        {
            (reds[i], greens[i]) = GetChannels(tif, i);
        }

        return (reds, greens);
    }

    public static Bitmap ToSDBitmap(this byte[] bytes)
    {
        using MemoryStream ms = new(bytes);
        Bitmap bmp = new(ms);
        return bmp;
    }

    public static Bitmap ToSDBitmap(this RasterSharp.Image img)
    {
        return img.GetBitmapBytes().ToSDBitmap();
    }

    public static RasterSharp.Channel[] SubtractNoiseFloor(RasterSharp.Channel[] images, double percentile)
    {
        if (percentile == 0)
            return images;

        return images.Select(x => SubtractNoiseFloor(x, percentile)).ToArray();
    }

    public static RasterSharp.Channel SubtractNoiseFloor(RasterSharp.Channel image, double percentile)
    {
        if (percentile == 0)
            return image;

        double[] sorted = image.GetValues().OrderBy(x => x).ToArray();
        int index = (int)(sorted.Length * percentile / 100.0);
        double floor = sorted[index];

        RasterSharp.Channel image2 = new(image.Width, image.Height);
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                image2.SetValue(x, y, image.GetValue(x, y) - floor);
            }
        }

        return image2;
    }

    public static void Multiply(RasterSharp.Channel ch, double factor = .5)
    {

        for (int y = 0; y < ch.Height; y++)
        {
            for (int x = 0; x < ch.Width; x++)
            {
                double value = ch.GetValue(x, y) * factor;
                ch.SetValue(x, y, value);
            }
        }
    }
}
