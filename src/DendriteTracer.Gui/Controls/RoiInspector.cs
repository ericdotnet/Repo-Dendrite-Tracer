using DendriteTracer.Core;
using RasterSharp;
using ScottPlot;
namespace DendriteTracer.Gui;

public partial class RoiInspector : UserControl
{
    private Core.Analysis? Analysis;

    public RoiInspector()
    {
        InitializeComponent();
        hScrollBar1.ValueChanged += (s, e) => { UpdateImage(); };
    }

    public void LoadROIs(Core.Analysis analysis)
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

        Visible = Analysis.RoiCount > 0;
        if (Analysis.RoiCount == 0)
            return;

        pictureBox1.Image = Analysis.RoiImagesMerge[Analysis.SelectedFrame, Analysis.SelectedRoi].ToBitmap();


        var oldImage = pictureBox2.Image;
        pictureBox2.Image = Analysis.RoiMaskImages[Analysis.SelectedFrame, Analysis.SelectedRoi].ToBitmap();
        oldImage?.Dispose();

        var curves = Analysis.GetRoiCurvesForFrame(Analysis.SelectedFrame);

        double[] sortedRedValues = Analysis.RoiImagesRed[Analysis.SelectedFrame, Analysis.SelectedRoi]
            .GetValues()
            .OrderBy(x => x)
            .ToArray();  

        formsPlot1.Plot.Clear();
        formsPlot1.Plot.AddSignal(sortedRedValues, sortedRedValues.Length / 100.0);
        formsPlot1.Plot.AddHorizontalLine(Analysis.RoiNoiseFloors[Analysis.SelectedFrame, Analysis.SelectedRoi], System.Drawing.Color.Black, style: LineStyle.Dot, label: "Noise Floor");
        formsPlot1.Plot.AddHorizontalLine(Analysis.RoiThresholds[Analysis.SelectedFrame, Analysis.SelectedRoi], System.Drawing.Color.Black, style: LineStyle.Dash, label: "Threshold");
        formsPlot1.Plot.Legend(true, Alignment.UpperLeft);

        formsPlot1.Plot.XLabel("Distribution (%)");
        formsPlot1.Plot.YLabel("Fluorescence");
        formsPlot1.Refresh();
    }
}
