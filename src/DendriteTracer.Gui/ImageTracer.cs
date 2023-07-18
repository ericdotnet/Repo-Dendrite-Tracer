using DendriteTracer.Core;

namespace DendriteTracer.Gui;

public partial class ImageTracer : UserControl
{
    public Analysis? Analysis = null;

    public event EventHandler<Analysis> AnalysisChanged = delegate { };

    public ImageTracer()
    {
        InitializeComponent();

        hScrollBar1.ValueChanged += (s, e) => RedrawFrame();
        pictureBox1.MouseDown += PictureBox1_MouseDown;
        pictureBox1.MouseMove += PictureBox1_MouseMove;

    }

    private void PictureBox1_MouseDown(object? sender, MouseEventArgs e)
    {
        if (Analysis is null)
            return;

        if (e.Button == MouseButtons.Left)
        {
            float scaleX = (float)Analysis.Proj.Width / pictureBox1.Width;
            float scaleY = (float)Analysis.Proj.Height / pictureBox1.Height;
            Analysis.Tracing.Add(e.X * scaleX, e.Y * scaleY);
        }
        else if (e.Button == MouseButtons.Right)
        {
            Analysis.Tracing.Clear();
        }

        RedrawFrame();
    }

    private void PictureBox1_MouseMove(object? sender, MouseEventArgs e)
    {
        // TODO: enable click drag points
    }

    public void LoadAnalysis(Analysis analysis)
    {
        Analysis = analysis;
        RedrawFrame();
    }

    public void RedrawFrame()
    {
        if (Analysis is null)
            return;

        hScrollBar1.Value = Math.Min(Analysis.FrameCount, hScrollBar1.Value);
        hScrollBar1.Maximum = Analysis.FrameCount;
        Analysis.SelectedFrame = hScrollBar1.Value - 1;
        label1.Text = Analysis.SelectedFrameTitle;

        Image? oldImage = pictureBox1.Image;
        pictureBox1.Image = Analysis.GetAnnotatedFrame();
        oldImage?.Dispose();

        AnalysisChanged.Invoke(this, Analysis);
    }
}