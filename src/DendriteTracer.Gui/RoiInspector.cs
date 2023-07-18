using DendriteTracer.Core;
using ScottPlot;

namespace DendriteTracer.Gui;

public partial class RoiInspector : UserControl
{
    private Analysis? Analysis;

    public RoiInspector()
    {
        InitializeComponent();
        hScrollBar1.ValueChanged += (s, e) => { UpdateImage(); };
    }

    public void LoadROIs(Analysis analysis)
    {
        Visible = analysis.RoiCount > 0;
        if (analysis.RoiCount == 0)
            return;

        Analysis = analysis;

        hScrollBar1.Value = Math.Min(hScrollBar1.Value, analysis.RoiCount);
        hScrollBar1.Maximum = analysis.RoiCount;

        UpdateImage();
    }

    public void UpdateImage()
    {
        if (Analysis is null)
            return;

        Analysis.SelectedRoi = hScrollBar1.Value - 1;
        label1.Text = Analysis.SelectedRoiTitle;

        // TODO: dedup
        RoiCollectionData data = Analysis.GetRoiData(Analysis.SelectedFrame);

        Visible = data.RoiCount > 0;
        if (data.RoiCount == 0)
            return;

        (double floor, double threshold) = data.GetThreshold(
            percent: Analysis.Settings.PixelThresholdFloor_Percent,
            multiple: Analysis.Settings.PixelThreshold_Multiple,
            roiIndex: Analysis.SelectedRoi);

        pictureBox1.Image = data.GetMergedImage(Analysis.SelectedRoi).ToBitmap();

        var oldImage = pictureBox2.Image;
        pictureBox2.Image = data.GetThresholdImage(threshold, Analysis.SelectedRoi).ToBitmap();
        oldImage?.Dispose();

        formsPlot1.Plot.Clear();
        formsPlot1.Plot.AddSignal(data.RedValuesSorted[Analysis.SelectedRoi], data.RedValuesSorted.Length / 100.0);
        formsPlot1.Plot.AddHorizontalLine(floor, System.Drawing.Color.Black, style: LineStyle.Dot, label: "Noise Floor");
        formsPlot1.Plot.AddHorizontalLine(threshold, System.Drawing.Color.Black, style: LineStyle.Dash, label: "Threshold");
        formsPlot1.Plot.Legend(true, Alignment.UpperLeft);

        formsPlot1.Plot.XLabel("Distribution (%)");
        formsPlot1.Plot.YLabel("Fluorescence");
        formsPlot1.Refresh();
    }
}
