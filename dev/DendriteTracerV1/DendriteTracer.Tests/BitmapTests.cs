using DendriteTracer.Core;

namespace DendriteTracer.Tests;

public class BitmapTests
{
    [Test]
    public void Test_Drawing_OnTif2ch()
    {
        SciTIF.TifFile tif = new(SampleData.TSERIES_2CH_PATH);
        SciTIF.Image red = tif.GetImage(frame: 0, slice: 0, channel: 0);
        SciTIF.Image green = tif.GetImage(frame: 0, slice: 0, channel: 1);
        Bitmap bmp = ImageOperations.MakeBitmap(red, green);

        Rectangle rect1 = new(50, 60, 70, 80);
        bmp.FillRect(rect1, Colors.Blue);

        Rectangle rect2 = new(13, 69, 123, 222);
        bmp.DrawRect(rect2, Colors.Yellow);

        bmp.DrawLine(13, 69, 123, 222, Colors.White);

        List<Pixel> pixels = new() {
            new((int)(0.4925*256), (int)(0.4912*256)),
            new((int)(0.5840*256), (int)(0.4922*256)),
            new((int)(0.6211*256), (int)(0.4277*256)),
            new((int)(0.7148*256), (int)(0.4297*256)),
            new((int)(0.8867*256), (int)(0.5039*256)),
            new((int)(0.9258*256), (int)(0.6191*256)),
            new((int)(0.9395*256), (int)(0.6855*256)),
            new((int)(0.9004*256), (int)(0.7207*256)),
        };
        bmp.DrawLines(pixels, Colors.White);

        bmp.TestSave("test1.png");
    }

    [Test]
    public void Test_Bitmap_Crop()
    {
        SciTIF.TifFile tif = new(SampleData.RGB_PATH);
        SciTIF.Image green = tif.GetImage(frame: 0, slice: 0, channel: 1);
        Bitmap bmp = ImageOperations.MakeBitmap(green);

        Rectangle rect = new(26, 220, 26 + 12, 220 + 8);
        Bitmap crop = bmp.Crop(rect);
        crop.TestSave("test-crop.png");
    }

    [Test]
    public void Test_Bitmap_CropOffEdge()
    {
        Bitmap bmp = new(100, 100);

        Rectangle rect = new(90, 90, 110, 110);
        Bitmap crop = bmp.Crop(rect);

        Assert.That(crop.Width, Is.EqualTo(20));
        Assert.That(crop.Height, Is.EqualTo(20));
    }
}