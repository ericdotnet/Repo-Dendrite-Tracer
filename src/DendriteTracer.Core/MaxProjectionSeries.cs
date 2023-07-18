namespace DendriteTracer.Core;

public class MaxProjectionSeries
{
    private readonly SciTIF.TifFile Tif;
    public int Length { get; }
    public int Width { get; }
    public int Height { get; }

    public MaxProjectionSeries(string tifFilePath)
    {
        Tif = LoadTifWithErrorChecking(tifFilePath);
        Length = Tif.Frames;
        Width = Tif.Width;
        Height = Tif.Height;
    }

    private static SciTIF.TifFile LoadTifWithErrorChecking(string tifFilePath)
    {
        SciTIF.TifFile tif = new(tifFilePath);

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

        return tif;
    }

    public (RasterSharp.Channel red, RasterSharp.Channel green) GetChannels(int frame)
    {
        SciTIF.Image red = Tif.GetImage(frame, 0, 0);
        SciTIF.Image green = Tif.GetImage(frame, 0, 1);

        RasterSharp.Channel redChannel = new(red.Width, red.Height, red.Values);
        RasterSharp.Channel greenChannel = new(green.Width, green.Height, green.Values);

        return (redChannel.Clone(), greenChannel.Clone());
    }

    public (RasterSharp.Channel[] reds, RasterSharp.Channel[] greens) GetAllChannels()
    {
        RasterSharp.Channel[] reds = new RasterSharp.Channel[Tif.Frames];
        RasterSharp.Channel[] greens = new RasterSharp.Channel[Tif.Frames];

        for (int i = 0; i < Tif.Frames; i++)
        {
            (reds[i], greens[i]) = GetChannels(i);
        }

        return (reds, greens);
    }

    public byte[] GetPreviewImageBytes(int frame, double brightness)
    {
        (RasterSharp.Channel red, RasterSharp.Channel green) = GetChannels(frame);

        double max = 255 * brightness;
        red.Rescale(0, max);
        green.Rescale(0, max);

        RasterSharp.Image img = new(red, green, red);
        return img.GetBitmapBytes();
    }
}
