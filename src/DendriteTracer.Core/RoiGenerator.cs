using BitMiracle.LibTiff.Classic;
using System.Drawing;

namespace DendriteTracer.Core;

/// <summary>
/// This class is for loading a TSeries projection, tracing the dendrite, and generating ROIs.
/// </summary>
public class RoiGenerator
{
    public string TifFilePath { get; }
    public Tracing Tracing { get; }
    public RasterSharp.Channel[] RedImages { get; }
    public RasterSharp.Channel[] GreenImages { get; }
    public Bitmap[] MergedImages { get; }

    public int Width { get; }
    public int Height { get; }
    public int FrameCount { get; }
    public double[] FrameTimes { get; }

    public RoiGenerator(string tifFile, double noiseFloorPercentile = 0, double brightness = 1)
    {
        //MaxProjectionSeries proj = new(tifFile); // TODO: make this static
        SciTIF.TifFile tif = new(tifFile);
        Drawing.AssertValidTif(tif);
        TifFilePath = Path.GetFullPath(tifFile);
        Width = tif.Width;
        Height = tif.Height;
        (RedImages, GreenImages) = Drawing.GetAllChannels(tif);
        RedImages = Drawing.SubtractNoiseFloor(RedImages, noiseFloorPercentile); // TODO: pass in
        GreenImages = Drawing.SubtractNoiseFloor(GreenImages, noiseFloorPercentile); // TODO: pass in
        FrameCount = RedImages.Length;
        MergedImages = new Bitmap[RedImages.Length];
        RegenerateMergedImages(brightness);
        double micronsPerPixel = 1.17879356364206; // TODO: read from XML
        Tracing = new(Width, Height, (float)micronsPerPixel);
        FrameTimes = Enumerable.Range(0, FrameCount).Select(x => (double)x).ToArray();// TODO: read from XML
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

    public RoiCollection CalculateRois(double thresholdFloor, double thresholdMult)
    {
        return new(this, thresholdFloor, thresholdMult);
    }
}