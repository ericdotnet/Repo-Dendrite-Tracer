using BitMiracle.LibTiff.Classic;
using FluentAssertions;
using System.Windows.Forms;
using System.Text;
using System.Xml.Linq;
using System.Drawing;

namespace ImageRatioTool.Tests;

public class Tests
{
    [Test]
    public void Test_SampleData_RatiometricSingleImage()
    {
        SciTIF.TifFile tif = new(ImageRatioTool.SampleData.RatiometricImage);
        tif.Frames.Should().Be(1);
        tif.Slices.Should().Be(1);
        tif.Channels.Should().Be(2);

        SciTIF.Image red = tif.GetImage(0, 0, 0);
        red.GetPixel(13, 17).Should().Be(162); // checked with ImageJ

        SciTIF.Image green = tif.GetImage(0, 0, 1);
        green.GetPixel(13, 17).Should().Be(422); // checked with ImageJ
    }

    [Test]
    public void Test_SampleData_RatiometricTSeries()
    {
        SciTIF.TifFile tif = new(ImageRatioTool.SampleData.RatiometricImageSeries);
        tif.Frames.Should().Be(24);
        tif.Slices.Should().Be(1);
        tif.Channels.Should().Be(2);
    }

    [Test]
    public void Test_SampleData_ReadScaleMetadata()
    {
        double micronsPerPixel = TifFileOperations.GetMicronsPerPixel(ImageRatioTool.SampleData.RatiometricImageSeries);
        micronsPerPixel.Should().BeApproximately(1.1788, precision: 1e-4);
    }

    [Test]
    public void Test_Xml_Times()
    {
        double[] seconds = XmlFileOperations.GetSequenceTimes(ImageRatioTool.SampleData.RatiometricImageSeriesXML);
        double[] minutes = seconds.Select(x => x / 60).ToArray();
        minutes.First().Should().Be(0);
        minutes.Last().Should().BeApproximately(30, 1);
    }

    [Test]
    public void Test_Fixed_TIF()
    {
        SciTIF.TifFile tif = new(ImageRatioTool.SampleData.FixedTif);
        tif.Frames.Should().Be(20);
        tif.Slices.Should().Be(1);
        tif.Channels.Should().Be(2);

        for (int i=0; i<tif.Frames; i++)
        {
            SciTIF.Image red = tif.GetImage(i, 0, 0);
            SciTIF.Image green = tif.GetImage(i, 0, 1);
            Bitmap display = ImageOperations.MakeDisplayImage(red, green, downscale: false);

            string saveAs = Path.GetFullPath($"display-{i:00}.png");
            display.Save(saveAs);
            Console.WriteLine(saveAs);
        }
        
    }
}