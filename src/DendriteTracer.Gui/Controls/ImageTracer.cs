using DendriteTracer.Core;

namespace DendriteTracer.Gui;

public partial class ImageTracer : UserControl
{
    public RoiGenerator? RoiGen;

    public event EventHandler RoisChanged = delegate { };
    public event EventHandler FrameChanged = delegate { };
    public double SubtractionFloor => cbImageSubtractionEnabled.Checked ? (double)nudImageSubtractionFloor.Value : 0;
    public int SelectedFrame => hScrollBar1.Value - 1;
    private int SelectedRoi;

    public ImageTracer()
    {
        InitializeComponent();
        lblSpacingPx.Text = string.Empty;
        lblRadiusPx.Text = string.Empty;
        lblAreaPx.Text = string.Empty;

        // file selection
        AllowDrop = true;

        btnSelectFile.Click += (s, e) =>
        {
            OpenFileDialog diag = new() { Filter = "TIF files (*.tif, *.tiff)|*.tif;*.tiff" };
            if (diag.ShowDialog() == DialogResult.OK)
            {
                LoadTif(diag.FileName);
            }
        };

        DragEnter += (s, e) =>
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        };

        DragDrop += (s, e) =>
        {
            string[] paths = (string[])e.Data!.GetData(DataFormats.FileDrop)!;
            LoadTif(paths.First());
        };

        // these things change the ROI generator and trigger reanalysis
        nudRoiRadius.ValueChanged += (s, e) =>
        {
            if (RoiGen is null) return;
            RoiGen.Tracing.RoiRadius_Microns = (float)nudRoiRadius.Value;
            RedrawFrame(true);
        };

        nudRoiSpacing.ValueChanged += (s, e) =>
        {
            if (RoiGen is null) return;
            RoiGen.Tracing.RoiSpacing_Microns = (float)nudRoiSpacing.Value;
            RedrawFrame(true);
        };

        cbRoiCirular.CheckedChanged += (s, e) =>
        {
            if (RoiGen is null) return;
            RoiGen.Tracing.IsCircular = cbRoiCirular.Checked;
            RedrawFrame(true);
        };

        hScrollBar1.ValueChanged += (s, e) =>
        {
            RedrawFrame();
            FrameChanged.Invoke(this, EventArgs.Empty);
        };

        nudImageSubtractionFloor.ValueChanged += (s, e) =>
        {
            ReloadTif();
        };

        cbImageSubtractionEnabled.CheckedChanged += (s, e) =>
        {
            nudImageSubtractionFloor.Enabled = cbImageSubtractionEnabled.Checked;
            ReloadTif();
        };

        // these things just change the display and don't leave this control
        nudBrightness.ValueChanged += (s, e) =>
        {
            RoiGen?.RegenerateMergedImages((double)nudBrightness.Value);
            RedrawFrame();
        };
        cbSpines.CheckedChanged += (s, e) => RedrawFrame();
        cbRois.CheckedChanged += (s, e) => RedrawFrame();

        pictureBox1.MouseDown += PictureBox1_MouseDown;
        pictureBox1.MouseUp += PictureBox1_MouseUp;
        pictureBox1.MouseMove += PictureBox1_MouseMove;

    }

    public void SetSelectedRoi(int roi)
    {
        SelectedRoi = roi;
        RedrawFrame();
    }

    private void ReloadTif()
    {
        if (RoiGen is null)
            return;
        var tracing = RoiGen.Tracing;
        RoiGen = new(RoiGen.TifFilePath, SubtractionFloor, (double)nudBrightness.Value);
        RoiGen.Tracing.AddRange(tracing.Points.ToArray());
        RedrawFrame(true);
    }

    private void PictureBox1_MouseUp(object? sender, MouseEventArgs e)
    {
        SpineBeingDragged = null;
        RedrawFrame(true);
    }

    private int? SpineBeingDragged = null;

    private void PictureBox1_MouseDown(object? sender, MouseEventArgs e)
    {
        if (RoiGen is null)
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
                float scaleX = (float)RoiGen.Width / pictureBox1.Width;
                float scaleY = (float)RoiGen.Height / pictureBox1.Height;
                RoiGen.Tracing.Add(e.X * scaleX, e.Y * scaleY);
            }
        }
        else if (e.Button == MouseButtons.Right)
        {
            RoiGen.Tracing.Clear();
        }

        RedrawFrame();
    }

    private int? GetSpineIndexUnderMouse(MouseEventArgs e, double snapDistance = 5)
    {
        if (RoiGen is null)
            return null;

        double closestDistance = double.PositiveInfinity;
        int closestIndex = -1;

        for (int i = 0; i < RoiGen.Tracing.Count; i++)
        {
            float scaleX = (float)RoiGen.Width / pictureBox1.Width;
            float scaleY = (float)RoiGen.Height / pictureBox1.Height;
            float mouseX = e.X * scaleX;
            float mouseY = e.Y * scaleY;
            float dX = Math.Abs(RoiGen.Tracing.Points[i].X - mouseX);
            float dY = Math.Abs(RoiGen.Tracing.Points[i].Y - mouseY);
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
        if (RoiGen is null)
            return;

        if (SpineBeingDragged.HasValue)
        {
            Cursor = Cursors.Hand;
            float scaleX = (float)RoiGen.Width / pictureBox1.Width;
            float scaleY = (float)RoiGen.Height / pictureBox1.Height;
            RoiGen.Tracing.Points[SpineBeingDragged.Value] = new(e.X * scaleX, e.Y * scaleY);
            RedrawFrame();
        }
        else
        {
            int? indexUnderMouse = GetSpineIndexUnderMouse(e);
            Cursor = indexUnderMouse is null ? Cursors.Default : Cursors.Hand;
        }
    }

    public void LoadTif(string tifFilePath, PixelLocation[]? initialPoints = null)
    {
        RoiGen = new(tifFilePath, 20, (double)nudBrightness.Value);
        RoiGen.Tracing.RoiSpacing_Microns = (double)nudRoiSpacing.Value;
        RoiGen.Tracing.RoiRadius_Microns = (double)nudRoiRadius.Value;
        RoiGen.Tracing.IsCircular = cbRoiCirular.Checked;

        if (initialPoints is not null)
            RoiGen.Tracing.AddRange(initialPoints);

        RedrawFrame(true);
    }

    bool RenderingNow = false;
    public void RedrawFrame(bool updateOtherControls = false)
    {
        if (RoiGen is null)
            return;

        if (RenderingNow && !updateOtherControls)
        {
            return;
        }

        lblSpacingPx.Text = Math.Round(RoiGen.Tracing.Spacing_Px, 2).ToString() + " px";
        lblRadiusPx.Text = Math.Round(RoiGen.Tracing.Radius_Px, 2).ToString() + " px";
        lblAreaPx.Text = Math.Round(RoiGen.Tracing.RoiArea_Microns, 2).ToString() + " µm²";

        RenderingNow = true;

        hScrollBar1.Value = Math.Min(RoiGen.FrameCount, hScrollBar1.Value);
        hScrollBar1.Maximum = RoiGen.FrameCount;

        label1.Text = $"Frame {SelectedFrame + 1} of {RoiGen.FrameCount}";

        Image? oldImage = pictureBox1.Image;
        pictureBox1.Image = Drawing.DrawTracingAndRois(RoiGen.MergedImages[SelectedFrame], RoiGen.Tracing, cbSpines.Checked, cbRois.Checked, SelectedRoi);
        oldImage?.Dispose();

        pictureBox1.Invalidate();
        Application.DoEvents();

        if (updateOtherControls)
        {
            RoisChanged.Invoke(this, EventArgs.Empty);
        }

        RenderingNow = false;
    }
}