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
        Visible = analysis.RoiCount > 0;
        if (analysis.RoiCount == 0)
            return;

        var curves = analysis.GetRoiCurvesForFrame(analysis.SelectedFrame);

        formsPlot1.Plot.Clear();
        formsPlot1.Plot.XLabel("Distance (µm)");
        formsPlot1.Plot.YLabel("Fluorescence (AFU)");
        formsPlot1.Plot.AddScatter(curves.position, curves.red, Color.Red, label: "Red PMT");
        formsPlot1.Plot.AddScatter(curves.position, curves.green, Color.Green, label: "Green PMT");
        formsPlot1.Plot.Legend(true, Alignment.UpperRight);

        formsPlot2.Plot.Clear();
        formsPlot2.Plot.XLabel("Distance (µm)");
        formsPlot2.Plot.YLabel("Green/Red (%)");
        formsPlot2.Plot.AddScatter(curves.position, curves.ratio, Color.Blue);

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