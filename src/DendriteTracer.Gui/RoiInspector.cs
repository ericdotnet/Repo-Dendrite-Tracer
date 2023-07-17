using DendriteTracer.Core;
using ScottPlot;

namespace DendriteTracer.Gui;

public partial class RoiInspector : UserControl
{
    public event EventHandler<(RoiCollectionData, double)> RoiDataChanged = delegate { };

    RoiCollectionData? RoiData;

    public RoiInspector()
    {
        InitializeComponent();
        hScrollBar1.ValueChanged += (s, e) => UpdateImage();
        nudNoiseFloor.ValueChanged += (s, e) => UpdateImage();
        nudThreshold.ValueChanged += (s, e) => UpdateImage();
    }

    public void LoadRois(ImageWithTracing iwt)
    {
        RoiData = new(iwt);

        if (RoiData.Length == 0)
            return;

        if (hScrollBar1.Value > RoiData.Length - 1)
        {
            hScrollBar1.Value = RoiData.Length - 1;
        }

        hScrollBar1.Maximum = RoiData.Length - 1;

        UpdateImage();
    }

    public void UpdateImage()
    {
        if (RoiData is null)
            return;

        if (RoiData.Images.Length == 0)
            return;

        int roiIndex = hScrollBar1.Value;

        label1.Text = $"ROI {roiIndex + 1} of {RoiData.Length}";

        pictureBox1.Image = RoiData.Images[roiIndex].ToBitmap();

        int pixelCount = RoiData.RedValuesSorted[roiIndex].Length;
        int noiseFloorIndex = (int)(nudNoiseFloor.Value / 100 * pixelCount);
        double noiseFloorValue = RoiData.RedValuesSorted[roiIndex][noiseFloorIndex];
        double thresholdValue = noiseFloorValue * (double)nudThreshold.Value;

        var oldImage = pictureBox2.Image;
        pictureBox2.Image = RoiData.GetThresholdImage(thresholdValue, roiIndex).ToBitmap();
        oldImage?.Dispose();

        formsPlot1.Plot.Clear();
        formsPlot1.Plot.AddSignal(RoiData.RedValuesSorted[roiIndex], pixelCount / 100.0);
        formsPlot1.Plot.AddHorizontalLine(noiseFloorValue, System.Drawing.Color.Black, style: LineStyle.Dot, label: "Noise Floor");
        formsPlot1.Plot.AddHorizontalLine(thresholdValue, System.Drawing.Color.Black, style: LineStyle.Dash, label: "Threshold");
        formsPlot1.Plot.Legend(true, Alignment.UpperLeft);

        formsPlot1.Plot.XLabel("Distribution (%)");
        formsPlot1.Plot.YLabel("Fluorescence");
        formsPlot1.Refresh();

        RoiDataChanged.Invoke(this, (RoiData, thresholdValue));
    }
}
