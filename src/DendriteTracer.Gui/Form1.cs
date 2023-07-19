using DendriteTracer.Core;

namespace DendriteTracer.Gui;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        // When the image, trace, or ROI settings change, reanalyze everything
        imageTracer1.RoisChanged += (s, e) => UpdateAllRois();

        // When the frame slider moves, update the ROI inspector
        imageTracer1.FrameChanged += (s, e) => UpdateFrameAndRoi();

        // When the ROI slider moves, update the analysis window
        roiInspector1.SelectedRoiChanged += (s, e) => UpdateFrameAndRoi();

        roiConfigurator1.RoiSettingsChanged += (s, e) => UpdateAllRois();

        LoadSampleData();
    }

    private void UpdateAllRois()
    {
        if (imageTracer1.RoiGen is null)
            return;

        RoiCollection rois = imageTracer1.RoiGen.CalculateRois(roiConfigurator1.ThresholdFloor, roiConfigurator1.ThresholdMult);
        roiInspector1.LoadROIs(rois);
        resultsViewer1.LoadRois(rois);
    }

    private void UpdateFrameAndRoi()
    {
        imageTracer1.SetSelectedRoi(roiInspector1.SelectedRoi);
        roiInspector1.SetFrame(imageTracer1.SelectedFrame);
        resultsViewer1.SetSelectedFrameAndRoi(imageTracer1.SelectedFrame, roiInspector1.SelectedRoi);
    }

    private void LoadSampleData()
    {

        string[] possibleStartupImages =
        {
            "SampleData/MAX_TSeries-04132023-1214-2165.tif",
            "../../../../DendriteTracer.Tests/SampleData/MAX_TSeries-04132023-1214-2165.tif",
        };

        foreach (string path in possibleStartupImages)
        {
            string startupImage = Path.GetFullPath(path);

            if (!File.Exists(startupImage))
            {
                System.Diagnostics.Debug.WriteLine($"STARTUP IMAGE NOT FOUND: {startupImage}");
                continue;
            }

            PixelLocation[] points =
            {
                new(73, 186), new(90, 175), new(102.5, 159.5), new(110, 146),
                new(120, 135), new(131.5, 126.5), new(131, 113.5), new(129, 104),
                new(139.5, 89), new(149, 75.5), new(161, 65.5), new(179, 55.5),
                new(206, 39.5), new(204, 26),
            };

            imageTracer1.LoadTif(startupImage, points);
            return;
        }
    }
}
