using DendriteTracer.Core;
using RasterSharp;
using ScottPlot;

namespace DendriteTracer.Gui;

public partial class RoiInspector : UserControl
{
    public event EventHandler<ImageWithTracing> TracingChanged = delegate { };

    Channel[]? Reds;
    Channel[]? Greens;
    Bitmap[]? RoiImages;

    double[][]? RedsSortedValues;

    public RoiInspector()
    {
        InitializeComponent();
        hScrollBar1.ValueChanged += (s, e) => UpdateImage();
        nudNoiseFloor.ValueChanged += (s, e) => UpdateImage();
        nudThreshold.ValueChanged += (s, e) => UpdateImage();
    }

    public void LoadRois(ImageWithTracing iwt)
    {
        if (!iwt.Rois.Any())
            return;

        // TODO: this logic should go in its own class in the core library
        (Reds, Greens) = iwt.GetRoiChannels();
        MakePreviewImages();
        UpdateSortedValues();

        if (hScrollBar1.Value > Reds.Length - 1)
        {
            hScrollBar1.Value = Reds.Length - 1;
        }

        hScrollBar1.Maximum = Reds.Length - 1;

        UpdateImage();
    }

    private void MakePreviewImages()
    {
        if (Reds is null || Greens is null)
            return;

        RoiImages = new Bitmap[Reds.Length];

        for (int i = 0; i < Reds.Length; i++)
        {
            Channel red2 = Reds[i].Clone();
            Channel green2 = Greens[i].Clone();
            red2.Rescale();
            green2.Rescale();
            RasterSharp.Image img = new(red2, green2, red2);

            byte[] bytes = img.GetBitmapBytes();
            RoiImages[i] = bytes.ToBitmap();
        }
    }

    private void UpdateSortedValues()
    {
        if (Reds is null)
            return;

        RedsSortedValues = new double[Reds.Length][];

        for (int i = 0; i < Reds.Length; i++)
        {
            double[] values = Reds[i].GetValues();
            double[] values2 = new double[values.Length];
            Array.Copy(values, 0, values2, 0, values.Length);
            Array.Sort(values2);
            RedsSortedValues[i] = values2;
        }
    }

    public void UpdateImage()
    {
        if (RoiImages is null || RedsSortedValues is null)
            return;

        if (!RoiImages.Any())
            return;

        int roiindex = hScrollBar1.Value;

        label1.Text = $"ROI {roiindex + 1} of {RoiImages.Length}";

        pictureBox1.Image = RoiImages[roiindex];

        int noiseFloorIndex = (int)(nudNoiseFloor.Value / 100 * RedsSortedValues[roiindex].Length);
        double noiseFloorValue = RedsSortedValues[roiindex][noiseFloorIndex];
        double thresholdValue = noiseFloorValue * (double)nudThreshold.Value;

        UpdateThresholdImage(roiindex, thresholdValue);

        formsPlot1.Plot.Clear();
        formsPlot1.Plot.AddSignal(RedsSortedValues[roiindex], RedsSortedValues[roiindex].Length / 100.0);
        formsPlot1.Plot.AddHorizontalLine(noiseFloorValue, System.Drawing.Color.Black, style: ScottPlot.LineStyle.Dot, label: "Noise Floor");
        formsPlot1.Plot.AddHorizontalLine(thresholdValue, System.Drawing.Color.Black, style: ScottPlot.LineStyle.Dash, label: "Threshold");
        formsPlot1.Plot.Legend(true, Alignment.UpperLeft);

        formsPlot1.Plot.XLabel("Distribution (%)");
        formsPlot1.Plot.YLabel("Fluorescence");
        formsPlot1.Refresh();
    }

    private void UpdateThresholdImage(int roiIndex, double threshold)
    {
        if (Reds is null || Greens is null)
            return;

        RasterSharp.Image img = new(Reds[0].Width, Reds[0].Height);

        for (int y = 0; y < img.Height; y++)
        {
            for (int x = 0; x < img.Width; x++)
            {
                if (Reds[roiIndex].GetValue(x, y) < threshold)
                {
                    img.Red.SetValue(x, y, 0);
                    img.Green.SetValue(x, y, 0);
                    img.Blue.SetValue(x, y, 255);
                }
                else
                {
                    img.Red.SetValue(x, y, 255);
                    img.Green.SetValue(x, y, 0);
                    img.Blue.SetValue(x, y, 0);
                }
            }
        }

        var oldImage = pictureBox2.Image;
        pictureBox2.Image = img.GetBitmapBytes().ToBitmap();
        oldImage?.Dispose();
    }
}
