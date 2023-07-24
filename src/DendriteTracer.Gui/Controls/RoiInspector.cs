using DendriteTracer.Core;
using ScottPlot;
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

    private void SetPictureboxImage(PictureBox pb, Bitmap bmp1)
    {
        pb.BackColor = SystemColors.Control;
        Bitmap bmp2 = new(pb.Width, pb.Height);
        using Graphics gfx = Graphics.FromImage(bmp2);

        const bool USE_ANTIALIASING = true;
        gfx.InterpolationMode = USE_ANTIALIASING
            ? System.Drawing.Drawing2D.InterpolationMode.Bicubic
            : System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

        // zoom in a bit so the edges don't appear anti-aliased with transparency
        float padX = bmp2.Width / bmp1.Width;
        float padY = bmp2.Height / bmp1.Height;
        gfx.DrawImage(bmp1, -padX, -padY, bmp2.Width + padX * 2, bmp2.Height + padY * 2);
        pb.Image = bmp2;
    }

    public void UpdateImage()
    {
        if (RoiCollection is null)
            return;

        label1.Text = $"Frame {SelectedFrame + 1}, ROI {SelectedRoi + 1} of {RoiCollection.RoiCount}";
        SetPictureboxImage(pictureBox1, RoiCollection.MergedImages[SelectedFrame, SelectedRoi]);
        SetPictureboxImage(pictureBox2, RoiCollection.MaskImages[SelectedFrame, SelectedRoi]);

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

            if (RoiCollection.ThresholdFloorPercent != 0)
            {
                formsPlot1.Plot.AddVerticalLine(RoiCollection.ThresholdsByFrame[SelectedFrame] / RoiCollection.ThresholdMult, Color.Blue, style: LineStyle.Dot, label: "ROI Floor");
                formsPlot1.Plot.AddVerticalLine(RoiCollection.ThresholdsByFrame[SelectedFrame], Color.Blue, style: LineStyle.Dash, label: "ROI Threshold");
            }

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
