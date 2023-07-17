using SciTIF.LUTs;

namespace DendriteTracer.Core;

public class MaxProjectionSeries
{
    private readonly SciTIF.TifFile Tif;
    public int Length { get; }

    public MaxProjectionSeries(string tifFilePath)
    {
        Tif = LoadTifWithErrorChecking(tifFilePath);
        Length = Tif.Frames;
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

    public byte[] GetPreviewImageBytes(int frame)
    {
        (RasterSharp.Channel red, RasterSharp.Channel green) = GetChannels(frame);

        red.Rescale();
        green.Rescale();

        RasterSharp.Image img = new(red, green, red);
        return img.GetBitmapBytes();
    }
}
