using DendriteTracer.Core;
using RasterSharp;
using ScottPlot;
namespace DendriteTracer.Gui;

public partial class RoiInspector : UserControl
{
    private RoiCollection? RoiCollection;
    private int SelectedFrame;
    private int SelectedRoi => hScrollBar1.Value;

    public RoiInspector()
    {
        InitializeComponent();
        hScrollBar1.ValueChanged += (s, e) => { UpdateImage(); };
    }

    public void LoadROIs(RoiCollection roiCollection)
    {
        Visible = roiCollection.RoiCount > 0;
        if (roiCollection.RoiCount == 0)
            return;

        RoiCollection = roiCollection;
        hScrollBar1.Value = Math.Min(hScrollBar1.Value, RoiCollection.RoiCount - 1);
        hScrollBar1.Maximum = RoiCollection.RoiCount - 1;

        UpdateImage();
    }

    public void SetFrame(int frame)
    {
        SelectedFrame = frame;
        UpdateImage();
    }

    public void UpdateImage()
    {
        if (RoiCollection is null)
            return;

        label1.Text = $"Frame {SelectedFrame + 1}, ROI {SelectedRoi + 1} of {RoiCollection.RoiCount}";
        pictureBox1.Image = RoiCollection.MergedImages[SelectedFrame, SelectedRoi];
        pictureBox2.Image = RoiCollection.MaskImages[SelectedFrame, SelectedRoi];

        double[] allValues = RoiCollection.SortedRedPixels[SelectedFrame, SelectedRoi];
        double floor = RoiCollection.NoiseFloors[SelectedFrame, SelectedRoi];
        double threshold = RoiCollection.Thresholds[SelectedFrame, SelectedRoi];

        formsPlot1.Plot.Clear();
        formsPlot1.Plot.AddSignal(allValues, allValues.Length / 100.0);
        formsPlot1.Plot.AddHorizontalLine(floor, System.Drawing.Color.Black, style: LineStyle.Dot, label: "Noise Floor");
        formsPlot1.Plot.AddHorizontalLine(threshold, System.Drawing.Color.Black, style: LineStyle.Dash, label: "Threshold");
        formsPlot1.Plot.Legend(true, Alignment.UpperLeft);

        formsPlot1.Plot.XLabel("Distribution (%)");
        formsPlot1.Plot.YLabel("Fluorescence");
        formsPlot1.Refresh();
    }
}
