using DendriteTracer.Core;

namespace DendriteTracer.Gui;

public partial class RoiAnalyzer : UserControl
{
    public RoiAnalyzer()
    {
        InitializeComponent();
    }

    public void LoadRois(RoiCollectionData data, double threshold)
    {
        if (data.Images.Length == 0)
            return;

        double[] positions = ScottPlot.Generate.Consecutive(data.Length);

        (double[] redMeans, double[] greenMeans, double[] ratios) = data.GetCurves(threshold);

        formsPlot1.Plot.Clear();
        formsPlot1.Plot.XLabel("Distance (µm)");
        formsPlot1.Plot.YLabel("Fluorescence (AFU)");
        formsPlot1.Plot.AddScatter(positions, redMeans, System.Drawing.Color.Red, label: "Red PMT");
        formsPlot1.Plot.AddScatter(positions, greenMeans, System.Drawing.Color.Green, label: "Green PMT");
        formsPlot1.Plot.Legend(true, ScottPlot.Alignment.UpperRight);
        formsPlot1.Refresh();

        formsPlot2.Plot.Clear();
        formsPlot2.Plot.XLabel("Distance (µm)");
        formsPlot2.Plot.YLabel("Green/Red (%)");
        formsPlot2.Plot.AddScatter(positions, ratios, System.Drawing.Color.Blue);
        formsPlot2.Refresh();
    }
}