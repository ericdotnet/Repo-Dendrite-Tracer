using DendriteTracer.Core;
using RasterSharp;

namespace DendriteTracer.Gui;

public partial class RoiInspector : UserControl
{
    Bitmap[]? RoiImages;

    public RoiInspector()
    {
        InitializeComponent();
        hScrollBar1.ValueChanged += (s, e) => UpdateImage();
    }

    public void LoadRois(ImageWithTracing iwt)
    {
        if (!iwt.Rois.Any())
            return;

        RoiImages = new Bitmap[iwt.Rois.Length];

        for (int i = 0; i < iwt.Rois.Length; i++)
        {
            (Channel red, Channel green) = iwt.GetRoiChannels(i);

            Channel red2 = red.Clone();
            Channel green2 = green.Clone();
            red2.Rescale();
            green2.Rescale();
            RasterSharp.Image img = new(red2, green2, red2);

            byte[] bytes = img.GetBitmapBytes();
            RoiImages[i] = bytes.ToBitmap();
        }

        if (hScrollBar1.Value > RoiImages.Length - 1)
        {
            hScrollBar1.Value = RoiImages.Length - 1;
        }

        hScrollBar1.Maximum = RoiImages.Length - 1;

        UpdateImage();
    }

    public void UpdateImage()
    {
        if (RoiImages is null)
            return;

        if (!RoiImages.Any())
            return;

        pictureBox1.Image = RoiImages[hScrollBar1.Value];

        label1.Text = $"ROI {hScrollBar1.Value + 1} of {RoiImages.Length}";
    }
}
