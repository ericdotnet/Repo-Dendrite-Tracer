namespace DendriteTracer.Gui.Controls;

/// <summary>
/// Like a picturebox but with fine control of rendering
/// to carefully control anti-aliasing and pixel offset
/// </summary>
internal class RawPictureBox : Panel
{
    private Bitmap? _bitmap { get; set; } = null;
    public Bitmap? Bitmap
    {
        get => _bitmap;
        set
        {
            _bitmap = value;
            Invalidate();
        }
    }

    public RawPictureBox()
    {
        DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (Bitmap is null)
        {
            e.Graphics.Clear(Color.Red);
            return;
        }

        Rectangle destRect = new(0, 0, Width, Height);
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        e.Graphics.DrawImage(Bitmap, destRect);
    }
}
