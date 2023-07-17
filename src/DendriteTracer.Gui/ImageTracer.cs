namespace DendriteTracer.Gui;

public partial class ImageTracer : UserControl
{
    DendriteTracer.Core.MaxProjectionSeries? Proj;
    Bitmap[]? FrameImages;

    public ImageTracer()
    {
        InitializeComponent();
        hScrollBar1.ValueChanged += (s, e) => SetFrame(hScrollBar1.Value - 1);
    }

    public void LoadImge(string tifFilePath)
    {
        // Load the TIF
        tifFilePath = Path.GetFullPath(tifFilePath);
        Proj = new(tifFilePath);
        label1.Text = Path.GetFileName(tifFilePath);
        label3.Text = "Microns per pixel: ???";

        // Prepare all frame merge images
        FrameImages = new Bitmap[Proj.Length];
        for (int i = 0; i < Proj.Length; i++)
        {
            byte[] bytes = Proj.GetPreviewImageBytes(i);
            using MemoryStream ms = new(bytes);
            Bitmap bmp = new(ms);
            FrameImages[i] = bmp;
        }

        hScrollBar1.Value = 1;
        hScrollBar1.Maximum = Proj.Length;
        SetFrame(0);
    }

    private void SetFrame(int frame)
    {
        if (FrameImages is null)
            return;

        label2.Text = $"Frame {frame + 1} of {FrameImages.Length}";
        pictureBox1.Image = FrameImages[frame];
    }
}
