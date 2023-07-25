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
    public double NoiseFloor_Percent { get; }
    public bool NoiseFloor_IsEnabled { get; }

    public RoiGenerator(string tifFile, double noiseFloorPercentile, double brightness, bool noiseFloorEnabled)
    {
        string xmlFile = IO.PvXml.Locate(tifFile);
        double micronsPerPixel = IO.PvXml.GetMicronsPerPixel(xmlFile);
        FrameTimes = IO.PvXml.GetFrameTimes(xmlFile);

        SciTIF.TifFile tif = new(tifFile);
        Drawing.AssertValidTif(tif);
        TifFilePath = Path.GetFullPath(tifFile);
        NoiseFloor_Percent = noiseFloorPercentile;
        NoiseFloor_IsEnabled = noiseFloorEnabled;
        Width = tif.Width;
        Height = tif.Height;
        (RedImages, GreenImages) = Drawing.GetAllChannels(tif);
        RedImages = Drawing.SubtractNoiseFloor(RedImages, noiseFloorEnabled ? noiseFloorPercentile : 0);
        GreenImages = Drawing.SubtractNoiseFloor(GreenImages, noiseFloorEnabled ? noiseFloorPercentile : 0);
        FrameCount = RedImages.Length;
        MergedImages = new Bitmap[RedImages.Length];
        RegenerateMergedImages(brightness);
        Tracing = new(Width, Height, (float)micronsPerPixel);
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

    public RoiCollection CalculateRois(double thresholdFloor, double thresholdMult, bool thresholdEnabled)
    {
        return new(this, thresholdFloor, thresholdMult, thresholdEnabled);
    }
}