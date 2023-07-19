using System.Drawing;

namespace DendriteTracer.Core;

/// <summary>
/// This class is for loading a TSeries projection, tracing the dendrite, and generating ROIs.
/// </summary>
public class RoiGenerator
{
    public Tracing Tracing { get; }
    public RasterSharp.Channel[] RedImages { get; }
    public RasterSharp.Channel[] GreenImages { get; }
    public Bitmap[] MergedImages { get; }

    public int Width { get; }
    public int Height { get; }
    public int FrameCount { get; }

    public RoiGenerator(string tifFile, double brightness = 1)
    {
        MaxProjectionSeries proj = new(tifFile); // TODO: make this static
        Width = proj.Width;
        Height = proj.Height;
        (RedImages, GreenImages) = proj.GetAllChannels();
        FrameCount = RedImages.Length;
        MergedImages = new Bitmap[RedImages.Length];
        RegenerateMergedImages(brightness);
        Tracing = new(Width, Height);
    }

    public void RegenerateMergedImages(double brightness)
    {
        ArgumentNullException.ThrowIfNull(RedImages);
        ArgumentNullException.ThrowIfNull(GreenImages);
        ArgumentNullException.ThrowIfNull(MergedImages);

        for (int i = 0; i < RedImages.Length; i++)
        {
            var r = RedImages[i].Clone();
            var g = GreenImages[i].Clone();

            r.Rescale(0, 255 * brightness);
            g.Rescale(0, 255 * brightness);

            RasterSharp.Image img = new(r, g, r);
            MergedImages[i] = img.ToSDBitmap();
        }
    }
}