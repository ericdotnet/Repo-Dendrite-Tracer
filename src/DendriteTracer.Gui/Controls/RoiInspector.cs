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
        double[] frameRedValues = RoiCollection.SortedRedPixelsByFrame[SelectedFrame];

        //roiRedValues = roiRedValues.Select(x => Math.Log(x)).ToArray();
        //frameRedValues = frameRedValues.Select(x => Math.Log(x)).ToArray();

        try
        {
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.AddSignal(roiRedValues, roiRedValues.Length / 100.0, label: "ROI");
            formsPlot1.Plot.AddSignal(frameRedValues, frameRedValues.Length / 100.0, label: "Frame");
            formsPlot1.Plot.AddHorizontalLine(RoiCollection.ThresholdsByFrame[SelectedFrame], System.Drawing.Color.Black, style: LineStyle.Dash, label: "Threshold");
            formsPlot1.Plot.Legend(true, Alignment.UpperLeft);

            formsPlot1.Plot.Title("");
            formsPlot1.Plot.XLabel("Distribution (%)");
            formsPlot1.Plot.YLabel("Fluorescence");
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
