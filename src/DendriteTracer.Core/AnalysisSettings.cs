namespace DendriteTracer.Core;

public class AnalysisSettings
{
    public string TifFilePath { get; }
    public double ImageSubtractionFloor_Percent { get; set; } = 20;
    public double RoiSpacing_Microns { get; set; } = 10;
    public double RoiRadius_Microns { get; set; } = 15;
    public bool RoiIsCircular { get; set; } = true;
    public double PixelThresholdFloor_Percent { get; set; } = 50;
    public double PixelThreshold_Multiple { get; set; } = 2;
    public double Brightness { get; set; } = 1;

    public bool ImageSubtractionIsEnabled => ImageSubtractionFloor_Percent > 0;

    public double MicronsPerPixel { get; } = 1;
    public float RoiSpacing_Pixels => (float)(RoiSpacing_Microns / MicronsPerPixel);
    public float RoiRadius_Pixels => (float)(RoiRadius_Microns / MicronsPerPixel);

    public double[] FrameTimes { get; }

    public AnalysisSettings(string tifFilePath)
    {
        TifFilePath = tifFilePath;
        FrameTimes = Array.Empty<double>(); // TODO
        MicronsPerPixel = 1; // TODO
    }
}
