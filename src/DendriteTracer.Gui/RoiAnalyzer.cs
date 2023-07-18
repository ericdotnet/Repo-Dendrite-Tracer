using DendriteTracer.Core;
using ScottPlot;

namespace DendriteTracer.Gui;

public partial class RoiAnalyzer : UserControl
{
    public RoiAnalyzer()
    {
        InitializeComponent();
        nudRawMax.ValueChanged += (s, e) => UpdatePlots();
        nudRatioMax.ValueChanged += (s, e) => UpdatePlots();
    }

    public void LoadRois(Analysis analysis)
    {
        // TODO: DEDUP
        RoiCollectionData data = analysis.GetRoiData(analysis.SelectedFrame);

        Visible = data.RoiCount > 0;
        if (data.RoiCount == 0)
            return;

        (double floor, double threshold) = data.GetThreshold(
            percent: analysis.Settings.PixelThresholdFloor_Percent,
            multiple: analysis.Settings.PixelThreshold_Multiple,
            roiIndex: analysis.SelectedRoi);

        double[] positions = ScottPlot.Generate.Consecutive(data.RoiCount);

        (double[] redMeans, double[] greenMeans, double[] ratios) = data.GetCurves(threshold);

        formsPlot1.Plot.Clear();
        formsPlot1.Plot.XLabel("Distance (µm)");
        formsPlot1.Plot.YLabel("Fluorescence (AFU)");
        formsPlot1.Plot.AddScatter(positions, redMeans, System.Drawing.Color.Red, label: "Red PMT");
        formsPlot1.Plot.AddScatter(positions, greenMeans, System.Drawing.Color.Green, label: "Green PMT");
        formsPlot1.Plot.Legend(true, ScottPlot.Alignment.UpperRight);

        formsPlot2.Plot.Clear();
        formsPlot2.Plot.XLabel("Distance (µm)");
        formsPlot2.Plot.YLabel("Green/Red (%)");
        formsPlot2.Plot.AddScatter(positions, ratios, System.Drawing.Color.Blue);

        UpdatePlots();
    }

    public void UpdatePlots()
    {
        formsPlot1.Plot.SetAxisLimitsY(0, (double)nudRawMax.Value);
        formsPlot1.Refresh();

        formsPlot2.Plot.SetAxisLimitsY(0, (double)nudRatioMax.Value);
        formsPlot2.Refresh();
    }
}