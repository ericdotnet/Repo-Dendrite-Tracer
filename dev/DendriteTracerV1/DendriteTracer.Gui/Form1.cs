using DendriteTracer.Core;

namespace DendriteTracer.Gui;

using PixelBitmap = DendriteTracer.Core.Bitmap;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        nudRoiRadius.Value = imageTracerControl1.RoiRadius;
        nudRoiSpacing.Value = imageTracerControl1.RoiSpacing;

        string initialPath = "124,126; 149,126; 154,118; 164,110; " +
            "186,111; 193,110; 207,118; 222,127; 233,133; 232,145; " +
            "237,153; 238,164; 238,173; 238,179; 231,184;";

        imageTracerControl1.DendritePath.LoadFromString(initialPath);

        Load += (s, e) =>
        {
            string startupImagePath = Path.GetFullPath("../../../../../../data/tseries/TSeries-03022023-1227-2098-2ch.tif");
            if (File.Exists(startupImagePath))
                LoadTif(startupImagePath);
        };

        imageTracerControl1.PointsChanged += (s, e) =>
        {
            //System.Diagnostics.Debug.WriteLine(imageTracerControl1.DendritePath.GetPointsString());
        };
    }

    private void nudMicronsPerPx_ValueChanged(object sender, EventArgs e) => UpdateRois();

    private void nudRoiSpacing_ValueChanged(object sender, EventArgs e) => UpdateRois();

    private void nudRoiRadius_ValueChanged(object sender, EventArgs e) => UpdateRois();

    void LoadTif(string tifFilePath)
    {
        SciTIF.TifFile tif = new(tifFilePath);

        if (tif.Channels != 2)
            throw new InvalidOperationException("Tif file must have 2 channels");

        if (tif.Frames <= 1)
            throw new InvalidOperationException("Tif file must have multiple frames");

        if (tif.Slices != 1)
            throw new InvalidOperationException("Tif file must be a projection image (not a stack)");

        SciTIF.Image red = tif.GetImage(frame: 0, slice: 0, channel: 0);
        SciTIF.Image green = tif.GetImage(frame: 0, slice: 0, channel: 1);

        PixelBitmap bmp = ImageOperations.MakeBitmap(red, green);
        imageTracerControl1.SetImage(bmp);
        Text = Path.GetFileName(tifFilePath);
    }

    private void PutInPicturebox(PixelBitmap bmp, PictureBox pb)
    {
        bmp.Multiply(10);

        byte[] bytes = bmp.GetBitmapBytes();
        using MemoryStream ms = new(bytes);
        using Image img = System.Drawing.Bitmap.FromStream(ms);

        System.Drawing.Bitmap bmp2 = new(pb.Width, pb.Height);
        pb.SizeMode = PictureBoxSizeMode.StretchImage;
        using Graphics gfx = Graphics.FromImage(bmp2);
        gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        gfx.DrawImage(img, 0, 0, bmp2.Width, bmp2.Height);

        Image? bmpOld = pb.Image;
        pb.Image = bmp2;
        bmpOld?.Dispose();
    }

    private void UpdateRois()
    {
        //float micronsPerPixel = 1;
        imageTracerControl1.RoiRadius = (int)nudRoiRadius.Value;
        imageTracerControl1.RoiSpacing = (int)nudRoiSpacing.Value;

        imageTracerControl1.AnnotateImage();

        PixelBitmap[] bmps = imageTracerControl1.GetRoiImages();
        if (!bmps.Any())
            return;

        hsbRoi.Value = 0;
        hsbRoi.Maximum = bmps.Length;
        PutInPicturebox(bmps[0], pbRoi);
    }
}
