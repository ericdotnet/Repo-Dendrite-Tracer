using DendriteTracer.Core;
using System.Windows.Forms;

namespace DendriteTracer.Gui;

public partial class ImageTracer : UserControl
{
    public Analysis? Analysis = null;

    public event EventHandler<Analysis> AnalysisChanged = delegate { };

    private System.Windows.Forms.Timer EventTimer = new() { Enabled = true, Interval = 100 };

    public ImageTracer()
    {
        InitializeComponent();

        hScrollBar1.ValueChanged += (s, e) => RedrawFrame(true);
        pictureBox1.MouseDown += PictureBox1_MouseDown;
        pictureBox1.MouseUp += PictureBox1_MouseUp;
        pictureBox1.MouseMove += PictureBox1_MouseMove;

        //EventTimer.Tick += EventTimer_Tick;
    }

    private void PictureBox1_MouseUp(object? sender, MouseEventArgs e)
    {
        SpineBeingDragged = null;
        RedrawFrame(true);
    }

    private int? SpineBeingDragged = null;

    private void PictureBox1_MouseDown(object? sender, MouseEventArgs e)
    {
        if (Analysis is null)
            return;

        if (e.Button == MouseButtons.Left)
        {

            int? indexUnderMouse = GetSpineIndexUnderMouse(e);

            if (indexUnderMouse.HasValue)
            {
                // drag existing point
                SpineBeingDragged = indexUnderMouse;
                Cursor = Cursors.Hand;
            }
            else
            {
                // add point
                float scaleX = (float)Analysis.Proj.Width / pictureBox1.Width;
                float scaleY = (float)Analysis.Proj.Height / pictureBox1.Height;
                Analysis.Tracing.Add(e.X * scaleX, e.Y * scaleY);
            }
        }
        else if (e.Button == MouseButtons.Right)
        {
            Analysis.Tracing.Clear();
        }

        RedrawFrame();
    }

    private int? GetSpineIndexUnderMouse(MouseEventArgs e, double snapDistance = 5)
    {
        if (Analysis is null)
            return null;

        double closestDistance = double.PositiveInfinity;
        int closestIndex = -1;

        for (int i = 0; i < Analysis.Tracing.Count; i++)
        {
            float scaleX = (float)Analysis.Proj.Width / pictureBox1.Width;
            float scaleY = (float)Analysis.Proj.Height / pictureBox1.Height;
            float mouseX = e.X * scaleX;
            float mouseY = e.Y * scaleY;
            float dX = Math.Abs(Analysis.Tracing.Points[i].X - mouseX);
            float dY = Math.Abs(Analysis.Tracing.Points[i].Y - mouseY);
            double distance = Math.Sqrt(dX * dX + dY * dY);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        return (closestDistance < snapDistance) ? closestIndex : null;
    }

    private void PictureBox1_MouseMove(object? sender, MouseEventArgs e)
    {
        if (Analysis is null)
            return;

        if (SpineBeingDragged.HasValue)
        {
            Cursor = Cursors.Hand;
            float scaleX = (float)Analysis.Proj.Width / pictureBox1.Width;
            float scaleY = (float)Analysis.Proj.Height / pictureBox1.Height;
            Analysis.Tracing.Points[SpineBeingDragged.Value] = new(e.X * scaleX, e.Y * scaleY);
            RedrawFrame();
        }
        else
        {
            int? indexUnderMouse = GetSpineIndexUnderMouse(e);
            Cursor = indexUnderMouse is null ? Cursors.Default : Cursors.Hand;
        }
    }

    public void LoadAnalysis(Analysis analysis)
    {
        Analysis = analysis;
        RedrawFrame(true);
    }

    bool RenderingNow = false;
    public void RedrawFrame(bool updateOtherControls = false)
    {
        if (Analysis is null)
            return;
        
        if (RenderingNow && !updateOtherControls)
        {
            return;
        }

        RenderingNow = true;

        hScrollBar1.Value = Math.Min(Analysis.FrameCount, hScrollBar1.Value);
        hScrollBar1.Maximum = Analysis.FrameCount;
        Analysis.SelectedFrame = hScrollBar1.Value - 1;
        label1.Text = Analysis.SelectedFrameTitle;

        Image? oldImage = pictureBox1.Image;
        pictureBox1.Image = Analysis.GetAnnotatedFrame();
        oldImage?.Dispose();

        pictureBox1.Invalidate();
        Application.DoEvents();

        if (updateOtherControls)
        {
            AnalysisChanged.Invoke(this, Analysis);
        }

        RenderingNow = false;
    }
}