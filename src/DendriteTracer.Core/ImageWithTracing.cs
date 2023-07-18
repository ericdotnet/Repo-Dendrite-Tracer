using RasterSharp;

namespace DendriteTracer.Core;

public class ImageWithTracing
{
    public Tracing Tracing { get; }
    public float RoiRadius { get; }
    public float RoiSpacing { get; }
    public Channel Red { get; }
    public Channel Green { get; }
    public Roi[] Rois { get; }

    public ImageWithTracing(Tracing tracing, float spacing, float radius, Channel red, Channel green)
    {
        Tracing = tracing;
        RoiSpacing = spacing;
        RoiRadius = radius;
        Red = red;
        Green = green;
        Rois = tracing.GetEvenlySpacedRois(spacing, radius);
    }

    public (Channel[] reds, Channel[] greens) GetRoiChannels()
    {
        Channel[] reds = new Channel[Rois.Length];
        Channel[] greens = new Channel[Rois.Length];

        for (int i = 0; i < Rois.Length; i++)
        {
            (reds[i], greens[i]) = GetRoiChannels(i);
        }

        return (reds, greens);
    }

    public (Channel red, Channel green) GetRoiChannels(int roiIndex)
    {
        if (Green is null)
            throw new NullReferenceException(nameof(Green));

        if (Rois is null)
            throw new NullReferenceException(nameof(Rois));

        Channel red = Crop(Red, Rois[roiIndex]);
        Channel green = Crop(Green, Rois[roiIndex]);

        return (red, green);
    }

    private static Channel Crop(Channel img, Roi roi)
    {
        return Crop(img, (int)roi.Left, (int)roi.Top, (int)roi.Width, (int)roi.Height);
    }

    private static Channel Crop(Channel img, int x, int y, int width, int height)
    {
        Channel img2 = new(width, height);

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
