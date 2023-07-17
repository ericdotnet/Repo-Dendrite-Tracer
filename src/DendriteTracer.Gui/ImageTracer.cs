using DendriteTracer.Core;

namespace DendriteTracer.Gui;

public partial class ImageTracer : UserControl
{
    MaxProjectionSeries? Proj;
    Bitmap[]? FrameImages;
    Tracing? Tracing;
    string? TifFilePath;

    public event EventHandler<ImageWithTracing> TracingChanged = delegate { };

    public ImageTracer()
    {
        InitializeComponent();

        hScrollBar1.ValueChanged += (s, e) => DrawTracing();
        nudSpacing.ValueChanged += (s, e) => DrawTracing();
        nudRadius.ValueChanged += (s, e) => DrawTracing();
        pictureBox1.MouseDown += PictureBox1_MouseDown;
        pictureBox1.MouseMove += PictureBox1_MouseMove;

        btnLaunch.Click += (s, e) =>
        {
            System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(TifFilePath)!);
        };

        btnLoadImage.Click += (s, e) =>
        {
            OpenFileDialog diag = new() { Filter = "TIF files (*.tif, *.tiff)|*.tif;*.tiff" };
            if (diag.ShowDialog() == DialogResult.OK)
            {
                LoadImge(diag.FileName);
            }
        };

        DragEnter += (s, e) =>
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        };

        DragDrop += (s, e) =>
        {
            string[] paths = (string[])e.Data!.GetData(DataFormats.FileDrop)!;
            LoadImge(paths.First());
        };
    }

    private void PictureBox1_MouseDown(object? sender, MouseEventArgs e)
    {
        if (Proj is null)
            return;

        if (Tracing is null)
            return;

        if (e.Button == MouseButtons.Left)
        {
            float scaleX = (float)Proj.Width / pictureBox1.Width;
            float scaleY = (float)Proj.Height / pictureBox1.Height;
            Tracing.Add(e.X * scaleX, e.Y * scaleY);
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
        if (Tracing is null)
            return;

        if (Proj is null)
            return;

        if (FrameImages is null)
            return;

        label2.Text = $"Frame {hScrollBar1.Value} of {hScrollBar1.Maximum}";
        int frameIndex = hScrollBar1.Value - 1;
        Bitmap bmp = new(FrameImages[frameIndex]);

        // TODO: replace with RasterSharp drawing
        using Graphics gfx = Graphics.FromImage(bmp);
        gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        PointF[] points = Tracing.GetPixels().Select(px => new PointF(px.X, px.Y)).ToArray();

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

        float spacing = (float)nudSpacing.Value;
        float radius = (float)nudRadius.Value;

        RectangleF[] roiRects = Tracing.GetEvenlySpacedRois(spacing, radius)
            .Select(roi => new RectangleF(roi.Left, roi.Top, roi.Width, roi.Height))
            .ToArray();

        foreach (RectangleF rect in roiRects)
        {
            gfx.DrawRectangle(Pens.Cyan, rect);
        }

        Image? oldImage = pictureBox1.Image;
        pictureBox1.Image = bmp;
        oldImage?.Dispose();

        (RasterSharp.Channel red, RasterSharp.Channel green) = Proj.GetChannels(frameIndex);
        ImageWithTracing iwt = new(Tracing, spacing, radius, red, green);
        TracingChanged.Invoke(this, iwt);
    }

    public void LoadImge(string tifFilePath, PixelLocation[]? initialPoints = null)
    {
        // Load the TIF
        TifFilePath = Path.GetFullPath(tifFilePath);
        Proj = new(TifFilePath);
        label1.Text = Path.GetFileName(TifFilePath);
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

        Tracing = new(Proj.Width, Proj.Height);

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
