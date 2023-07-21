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
            "./SampleData/MAX_TSeries-05312023-1239-2203.tif",
            "../../../../DendriteTracer.Tests/SampleData/MAX_TSeries-05312023-1239-2203.tif",
        };

        foreach (string path in possibleStartupImages)
        {
            string startupImage = Path.GetFullPath(path);

            if (!File.Exists(startupImage))
            {
                System.Diagnostics.Debug.WriteLine($"STARTUP IMAGE NOT FOUND: {startupImage}");
                continue;
            }

            Core.PixelLocation[] points =
            {
                new(101.69863, 194.5),
                new(116.72798, 168.5),
                new(123.741684, 141.5),
                new(138.77104, 119),
                new(155.8043, 95),
                new(168.32877, 82)
            };

            imageTracer1.LoadTif(startupImage, points);
            return;
        }
    }
}
