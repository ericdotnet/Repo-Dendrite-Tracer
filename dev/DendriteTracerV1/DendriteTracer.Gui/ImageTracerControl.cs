using DendriteTracer.Core;

namespace DendriteTracer.Gui;

public class ImageTracerControl : UserControl
{
    private bool RenderNeeded = false;

    private readonly System.Windows.Forms.Timer RenderTimer = new()
    {
        Interval = 20,
        Enabled = true
    };

    private readonly PictureBox PictureBox1 = new()
    {
        Dock = DockStyle.Fill,
        BackColor = SystemColors.ControlDark,
        Cursor = Cursors.Cross,
    };

    public readonly DendritePath DendritePath = new(0, 0);

    private Core.Bitmap? SourceData;

    private System.Drawing.Bitmap? SourceImage;

    private readonly int ControlPointRadius = 5;

    private int? DraggingPointIndex = null;

    public event EventHandler PointsChanged = delegate { };

    private float ScaleX => DendritePath is null ? 1 : (float)Width / DendritePath.Width;
    private float ScaleY => DendritePath is null ? 1 : (float)Height / DendritePath.Height;

    public int RoiSpacing { get; set; } = 5;
    public int RoiRadius { get; set; } = 15;

    public ImageTracerControl()
    {
        Controls.Add(PictureBox1);

        PictureBox1.MouseClick += (s, e) =>
        {
            if (SourceImage is null)
                return;

            if (DraggingPointIndex is not null)
            {
                AnnotateImage();
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                Pixel px = new((int)(e.X / ScaleX), (int)(e.Y / ScaleY)); // scale down
                DendritePath.Add(px);
                PointsChanged.Invoke(this, EventArgs.Empty);
                AnnotateImage();
                return;
            }

            if (e.Button == MouseButtons.Right)
            {
                DendritePath.Clear();
                PointsChanged.Invoke(this, EventArgs.Empty);
                AnnotateImage();
                return;
            }
        };

        PictureBox1.MouseMove += (s, e) =>
        {
            if (SourceImage is null)
                return;

            if (DraggingPointIndex is not null)
            {
                Pixel px = new((int)(e.X / ScaleX), (int)(e.Y / ScaleY)); // scale down
                DendritePath.Points[DraggingPointIndex.Value] = px;
                PointsChanged.Invoke(this, EventArgs.Empty);
                AnnotateImage();
                return;
            }

            int? index = GetPointUnderMouse(e.Location);
            Cursor = index is null ? Cursors.Cross : Cursors.Hand;
        };

        PictureBox1.MouseDown += (s, e) =>
        {
            DraggingPointIndex = GetPointUnderMouse(e.Location);
        };

        PictureBox1.MouseUp += (s, e) =>
        {
            DraggingPointIndex = null;
        };

        RenderTimer.Tick += (s, e) =>
        {
            if (RenderNeeded)
            {
                AnnotateImageNow();
                RenderNeeded = false;
            }
        };
    }

    private int? GetPointUnderMouse(PointF mouse)
    {
        if (SourceImage is null)
            return null;

        Pixel px = new((int)(mouse.X / ScaleX), (int)(mouse.Y / ScaleY)); // scale down

        for (int i = 0; i < DendritePath.Count; i++)
        {
            float dx = Math.Abs(DendritePath.Points[i].X - px.X);
            float dy = Math.Abs(DendritePath.Points[i].Y - px.Y);
            if (dx <= ControlPointRadius && dy <= ControlPointRadius)
            {
                return i;
            }
        }

        return null;
    }

    public void SetImage(Core.Bitmap bmp)
    {
        SourceData = bmp; // save it so we can extract ROIs later

        byte[] bytes = bmp.GetBitmapBytes();
        using MemoryStream ms = new(bytes);
        using Image img = System.Drawing.Bitmap.FromStream(ms);

        SourceImage?.Dispose();
        SourceImage = new(Width, Height);
        using Graphics gfx = Graphics.FromImage(SourceImage);
        gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        gfx.DrawImage(img, 0, 0, Width, Height);

        DendritePath.Resize(bmp.Width, bmp.Height);
        AnnotateImage();
    }

    public void AnnotateImage()
    {
        RenderNeeded = true;
    }

    public DendriteTracer.Core.Bitmap[] GetRoiImages()
    {
        if (SourceData is null)
            return Array.Empty<DendriteTracer.Core.Bitmap>();

        var rects = DendritePath.GetRois(RoiSpacing, RoiRadius).Select(roi => roi.Rectangle);

        var bmps = rects.Select(rect => SourceData.Crop(rect));

        return bmps.ToArray();
    }

    private void AnnotateImageNow()
    {
        if (SourceImage is null)
            return;

        System.Drawing.Bitmap bmp = new(SourceImage);
        using Graphics gfx = Graphics.FromImage(bmp);
        gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // draw dendrite line
        if (DendritePath.Count > 1)
        {
            PointF[] points = DendritePath.Points
                .Select(pt => new PointF(pt.X * ScaleX, pt.Y * ScaleY))
                .ToArray();

            gfx.DrawLines(Pens.White, points);
        }

        // draw dendrite control points
        foreach (Pixel px in DendritePath.Points)
        {
            RectangleF rect = new(
                x: px.X * ScaleX - ControlPointRadius,
                y: px.Y * ScaleY - ControlPointRadius,
                width: ControlPointRadius * 2,
                height: ControlPointRadius * 2);

            gfx.DrawEllipse(Pens.Yellow, rect);
        }

        // draw ROIs
        foreach (Roi roi in DendritePath.GetRois(RoiSpacing, RoiRadius))
        {
            RectangleF rect = new(
                x: roi.X * ScaleX - RoiRadius,
                y: roi.Y * ScaleY - RoiRadius,
                width: RoiRadius * 2,
                height: RoiRadius * 2);

            gfx.DrawRectangle(Pens.Gray, rect);
        }

        Image old = PictureBox1.Image;
        PictureBox1.Image = bmp;
        old?.Dispose();
    }
}
