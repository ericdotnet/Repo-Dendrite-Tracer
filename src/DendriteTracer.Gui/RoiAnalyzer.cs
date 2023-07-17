using DendriteTracer.Core;
using RasterSharp;

namespace DendriteTracer.Gui;

public partial class RoiAnalyzer : UserControl
{
    Channel[]? Reds;
    Channel[]? Greens;

    public RoiAnalyzer()
    {
        InitializeComponent();
    }

    public void LoadRois(ImageWithTracing iwt)
    {
        if (!iwt.Rois.Any())
            return;

        (Reds, Greens) = iwt.GetRoiChannels();

        // TODO: apply noise floor threshold to calculate mean
        double[] xs = ScottPlot.Generate.Consecutive(iwt.Rois.Length);
        double[] roiMeansRed = Reds.Select(x => Mean(x.GetValues())).ToArray();
        double[] roiMeansGreen = Greens.Select(x => Mean(x.GetValues())).ToArray();
        double[] roiGoR = Enumerable.Range(0, roiMeansRed.Length).Select(x => roiMeansGreen[x] / roiMeansRed[x] * 100).ToArray();

        formsPlot1.Plot.Clear();
        formsPlot1.Plot.XLabel("Distance (µm)");
        formsPlot1.Plot.YLabel("Fluorescence (AFU)");
        formsPlot1.Plot.AddScatter(xs, roiMeansRed, System.Drawing.Color.Red, label: "Red PMT");
        formsPlot1.Plot.AddScatter(xs, roiMeansGreen, System.Drawing.Color.Green, label: "Green PMT");
        formsPlot1.Plot.Legend(true, ScottPlot.Alignment.UpperRight);
        formsPlot1.Refresh();

        formsPlot2.Plot.Clear();
        formsPlot2.Plot.XLabel("Distance (µm)");
        formsPlot2.Plot.YLabel("Green/Red (%)");
        formsPlot2.Plot.AddScatter(xs, roiGoR, System.Drawing.Color.Blue);
        formsPlot2.Refresh();
    }

    static double Mean(double[] values) => values.Sum() / values.Length;
}