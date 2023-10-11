using DendriteTracer.Core;
using ScottPlot;
using System.Runtime.Intrinsics.X86;

namespace DendriteTracer.Gui;

public partial class RoiInspector : UserControl
{
    private RoiCollection? RoiCollection;
    private int SelectedFrame;
    public int SelectedRoi => hScrollBar1.Value;
    public event EventHandler SelectedRoiChanged = delegate { };

    public RoiInspector()
    {
        InitializeComponent();

        hScrollBar1.ValueChanged += (s, e) =>
        {
            UpdateImage();
            SelectedRoiChanged.Invoke(this, EventArgs.Empty);
        };
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

        groupBox1.Text = $"ROI {SelectedRoi + 1} of {RoiCollection.RoiCount}";

        pictureBox1.Bitmap = RoiCollection.MergedImages[SelectedFrame, SelectedRoi];

        double[] roiRedValues = RoiCollection.SortedRedPixelsByRoi[SelectedFrame, SelectedRoi];
        double[] roiRedValuesPercents = Enumerable.Range(0, roiRedValues.Length).Select(x => 100.0 * x / roiRedValues.Length).ToArray();

        double[] frameRedValues = RoiCollection.SortedRedPixelsByFrame[SelectedFrame];
        double[] frameRedValuesPercents = Enumerable.Range(0, frameRedValues.Length).Select(x => 100.0 * x / frameRedValues.Length).ToArray();

        double[] frameGreenValues = RoiCollection.SortedGreenPixelsByFrame[SelectedFrame];
        double[] frameGreenValuesPercents = Enumerable.Range(0, frameGreenValues.Length).Select(x => 100.0 * x / frameGreenValues.Length).ToArray();

        try
        {
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.AddScatterLines(roiRedValues, roiRedValuesPercents, Color.Black, 2, LineStyle.Dot, label: "ROI Red");
            formsPlot1.Plot.AddScatterLines(frameRedValues, frameRedValuesPercents, Color.Magenta, 2, LineStyle.Solid, label: "Frame Red");
            formsPlot1.Plot.AddScatterLines(frameGreenValues, frameGreenValuesPercents, Color.Green, 2, LineStyle.Solid, label: "Frame Green");

            formsPlot1.Plot.Legend(true, Alignment.LowerRight);

            formsPlot1.Plot.Title("");
            formsPlot1.Plot.XLabel("Fluorescence (AFU)");
            formsPlot1.Plot.YLabel("Cumulative Probability (%)");
            formsPlot1.Refresh();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);

            formsPlot1.Plot.Clear();
            formsPlot1.Plot.Title(ex.ToString());
            formsPlot1.Refresh();
        }
    }
}
