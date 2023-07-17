using DendriteTracer.Core;

namespace DendriteTracer.Tests;

internal class DendritePathTests
{
    [Test]
    public void Test_DendritePath_Drawing()
    {
        SciTIF.TifFile tif = new(SampleData.TSERIES_2CH_PATH);
        SciTIF.Image red = tif.GetImage(frame: 0, slice: 0, channel: 0);
        SciTIF.Image green = tif.GetImage(frame: 0, slice: 0, channel: 1);
        Bitmap bmp = ImageOperations.MakeBitmap(red, green);

        DendritePath dp = new(bmp.Width, bmp.Height);
        string initialPath = "124,126; 149,126; 154,118; 164,110; " +
           "186,111; 193,110; 207,118; 222,127; 233,133; 232,145; " +
           "237,153; 238,164; 238,173; 238,179; 231,184;";
        dp.LoadFromString(initialPath);

        Roi[] rois = dp.GetRois(50, 15);
        Bitmap bmpCrop = bmp.Crop(rois.First().Rectangle);
        bmpCrop.TestSave("trace-crop.bmp");

        // label and save
        dp.Draw(bmp);
        foreach (Roi roi in rois)
            bmp.DrawRect(roi.Rectangle, Colors.Magenta);
        bmp.TestSave("trace-draw.bmp");
    }
}