namespace DendriteTracer.Core;

/// <summary>
/// This object describes all user-provided ROI analysis settings.
/// </summary>
public struct RoiExperimentSettings
{
    public string TifFilePath { get; init; }

    public bool ImageFloor_IsEnabled { get; init; }
    public double ImageFloor_Percent { get; init; }

    public bool RoiIsCircular { get; init; }
    public double RoiSpacing_Microns { get; init; }
    public double RoiRadius_Microns { get; init; }

    public bool RoiThreshold_IsEnabled { get; init; }
    public double RoiFloor_Percent { get; init; }
    public double RoiThreshold_Multiple { get; init; }

    public PixelLocation[] Rois { get; init; }
}