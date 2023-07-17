using DendriteTracer.Core;

namespace DendriteTracer.Gui;

public partial class ImageTracer : UserControl
{
    MaxProjectionSeries? Proj;
    Bitmap[]? FrameImages;
    readonly ImageTracing Tracing = new();

    public ImageTracer()
    {
        InitializeComponent();
        hScrollBar1.ValueChanged += (s, e) => DrawTracing();
        nudSpacing.ValueChanged += (s, e) => DrawTracing();
        nudRadius.ValueChanged += (s, e) => DrawTracing();
        pictureBox1.MouseDown += PictureBox1_MouseDown;
        pictureBox1.MouseMove += PictureBox1_MouseMove;
    }

    private void PictureBox1_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Tracing.Add(e.X, e.Y);
        }
        else if (e.Button == MouseButtons.Right)
        {
            Tracing.Clear();
        }

        DrawTracing();
    }

    private void PictureBox1_MouseMove(object? sender, MouseEventArgs e)
    {
        // TODO: enable click drag points
    }

    private void DrawTracing()
    {
        if (FrameImages is null)
            return;

        label2.Text = $"Frame {hScrollBar1.Value} of {hScrollBar1.Maximum}";

        Bitmap bmp = new(FrameImages[hScrollBar1.Value - 1]);

        // TODO: replace with RasterSharp drawing
        using Graphics gfx = Graphics.FromImage(bmp);
        gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        PointF[] points = GetScaledTracingPoints();

        if (points.Length > 1)
        {
            gfx.DrawLines(Pens.Yellow, points);
        }

        foreach (PointF pt in points)
        {
            int r = 2;
            RectangleF rect = new(pt.X - r, pt.Y - r, r * 2, r * 2);
            gfx.DrawRectangle(Pens.Yellow, rect);
        }

        foreach (RectangleF rect in GetScaledRois())
        {
            gfx.DrawRectangle(Pens.Cyan, rect);
        }

        Image? oldImage = pictureBox1.Image;
        pictureBox1.Image = bmp;
        oldImage?.Dispose();
    }

    private PointF[] GetScaledTracingPoints()
    {
        if (Proj is null)
            return Array.Empty<PointF>();

        float scaleX = (float)Proj.Width / pictureBox1.Width;
        float scaleY = (float)Proj.Height / pictureBox1.Height;

        return Tracing.GetPixels()
            .Select(px => new PointF(px.X * scaleX, px.Y * scaleY))
            .ToArray();
    }

    private RectangleF[] GetScaledRois()
    {
        if (Proj is null)
            return Array.Empty<RectangleF>();

        float scaleX = (float)Proj.Width / pictureBox1.Width;
        float scaleY = (float)Proj.Height / pictureBox1.Height;

        List<RectangleF> rois = new();

        // TODO: display micron distances from XML
        float spacing = (float)nudSpacing.Value;
        float radius = (float)nudRadius.Value;
        foreach (Roi roi in Tracing.GetEvenlySpacedRois(spacing, radius))
        {
            float x = (roi.X - roi.R) * scaleX;
            float y = (roi.Y - roi.R) * scaleY;
            float w = roi.R * 2 * scaleX;
            float h = roi.R * 2 * scaleY;
            RectangleF rect = new(x, y, w, h);
            rois.Add(rect);
        }

        return rois.ToArray();
    }

    public void LoadImge(string tifFilePath, PixelLocation[]? initialPoints = null)
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

        Tracing.Clear();

        if (initialPoints is not null)
        {
            foreach (PixelLocation point in initialPoints)
            {
                Tracing.Add(point);
            }
        }

        hScrollBar1.Value = 1;
        hScrollBar1.Maximum = Proj.Length;
        DrawTracing();
    }
}
