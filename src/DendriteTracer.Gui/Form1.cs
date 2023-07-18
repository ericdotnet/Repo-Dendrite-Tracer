using DendriteTracer.Core;

namespace DendriteTracer.Gui;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        userInputs1.AnalysisChanged += (object? sender, Analysis analysis) =>
        {
            imageTracer1.LoadAnalysis(analysis);
        };

        imageTracer1.AnalysisChanged += (object? sender, Analysis analysis) =>
        {
            roiInspector1.LoadROIs(analysis);
            roiAnalyzer1.LoadRois(analysis);
        };

        LoadSampleData();
    }

    private void LoadSampleData()
    {
        string startupImage = Path.GetFullPath("../../../../DendriteTracer.Tests/SampleData/MAX_TSeries-04132023-1214-2165.tif");

        if (!File.Exists(startupImage))
        {
            System.Diagnostics.Debug.WriteLine($"STARTUP IMAGE NOT FOUND: {startupImage}");
            return;
        }

        PixelLocation[] points =
        {
            new(73, 186), new(90, 175), new(102.5, 159.5), new(110, 146),
            new(120, 135), new(131.5, 126.5), new(131, 113.5), new(129, 104),
            new(139.5, 89), new(149, 75.5), new(161, 65.5), new(179, 55.5),
            new(206, 39.5), new(219.5, 26), new(218, 14), new(216, 4),
        };

        userInputs1.LoadTif(startupImage, points);
    }
}
