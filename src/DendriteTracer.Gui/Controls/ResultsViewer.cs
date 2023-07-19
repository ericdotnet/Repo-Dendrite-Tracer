using DendriteTracer.Core;
using ScottPlot;

namespace DendriteTracer.Gui;

public partial class ResultsViewer : UserControl
{
    int SelectedFrame = 0;
    RoiCollection? RoiCollection;

    public ResultsViewer()
    {
        InitializeComponent();
        nudRawMax.ValueChanged += (s, e) => UpdatePlots();
        nudRatioMax.ValueChanged += (s, e) => UpdatePlots();
    }

    public void SetFrame(int frame)
    {
        SelectedFrame = frame;
        UpdatePlots();
    }

    public void LoadRois(RoiCollection roiCollection)
    {
        Visible = roiCollection.RoiCount > 0;
        if (roiCollection.RoiCount == 0)
            return;

        RoiCollection = roiCollection;
        UpdatePlots();
    }

    public void UpdatePlots()
    {
        if (RoiCollection is null)
            return;

        formsPlot1.Plot.Clear();
        formsPlot1.Plot.XLabel("Distance (µm)");
        formsPlot1.Plot.YLabel("Fluorescence (AFU)");
        formsPlot1.Plot.AddScatter(RoiCollection.Positions, RoiCollection.RedCurveByFrame[SelectedFrame], Color.Red, label: "Red PMT");
        formsPlot1.Plot.AddScatter(RoiCollection.Positions, RoiCollection.GreenCurveByFrame[SelectedFrame], Color.Green, label: "Green PMT");
        formsPlot1.Plot.Legend(true, Alignment.UpperRight);
        formsPlot1.Plot.SetAxisLimitsY(0, (double)nudRawMax.Value);
        formsPlot1.Refresh();

        formsPlot2.Plot.Clear();
        formsPlot2.Plot.XLabel("Distance (µm)");
        formsPlot2.Plot.YLabel("Green/Red (%)");
        formsPlot2.Plot.AddScatter(RoiCollection.Positions, RoiCollection.RatioCurveByFrame[SelectedFrame], Color.Blue);
        formsPlot2.Plot.SetAxisLimitsY(0, (double)nudRatioMax.Value);
        formsPlot2.Refresh();
    }
}