using System.Drawing;

namespace DendriteTracer.Core;

/// <summary>
/// This class is for breaking a projection series into a bunch of small ROIs and performing analyses on them.
/// ROI images are stored in 2D arrays (height = frame, width = roi).
/// </summary>
public class RoiCollection
{
    public int FrameCount { get; }
    public Roi[] Rois { get; }
    public double[] Positions { get; }
    public double[] Times { get; }
    public int RoiCount => Rois.Length;

    // TODO: replace 2d arrays with RoiData objects
    public RasterSharp.Channel[,] GreenImages { get; }
    public RasterSharp.Channel[,] RedImages { get; }
    public Bitmap[,] MergedImages { get; }
    public double[,][] SortedRedPixels { get; }
    public double[,] NoiseFloors { get; }
    public double[,] Thresholds { get; }
    public Bitmap[,] MaskImages { get; }
    public bool[,][,] Masks { get; }
    public double[,] RedMeans { get; }
    public double[,] GreenMeans { get; }
    public double[,] Ratios { get; }

    // TODO: replace with curve objects
    public double[][] RedCurveByFrame { get; }
    public double[][] GreenCurveByFrame { get; }
    public double[][] RatioCurveByFrame { get; }

    public RoiCollection(RoiGenerator roiGen, double thresholdFloorPercent = 50, double thresholdMult = 3)
    {
        FrameCount = roiGen.FrameCount;
        Rois = roiGen.Tracing.GetEvenlySpacedRois();
        Positions = Enumerable.Range(0, RoiCount).Select(x => (double)x * roiGen.Tracing.MicronsPerPixel).ToArray();
        Times = roiGen.FrameTimes;
        RedImages = Drawing.Crop(roiGen.RedImages, Rois);
        GreenImages = Drawing.Crop(roiGen.GreenImages, Rois);
        MergedImages = Drawing.GetMergedImages(RedImages, GreenImages);
        SortedRedPixels = ArrayOperations.GetSortedPixels(RedImages);
        NoiseFloors = ArrayOperations.GetNoiseFloors(SortedRedPixels, thresholdFloorPercent);
        Thresholds = ArrayOperations.GetThresholds(NoiseFloors, thresholdMult);
        (MaskImages, Masks) = Drawing.GetMaskImages(RedImages, Thresholds, roiGen.Tracing.IsCircular);
        RedMeans = ArrayOperations.GetMeans(RedImages, Masks);
        GreenMeans = ArrayOperations.GetMeans(GreenImages, Masks);
        Ratios = ArrayOperations.GetRatios(RedMeans, GreenMeans);
        RedCurveByFrame = ArrayOperations.GetCurveByFrame(RedMeans);
        GreenCurveByFrame = ArrayOperations.GetCurveByFrame(GreenMeans);
        RatioCurveByFrame = ArrayOperations.GetCurveByFrame(Ratios);
    }
}