using RasterSharp;
using System.Drawing;

namespace DendriteTracer.Tests;

public class RoiValueTests
{
    private readonly ITestOutputHelper Output;

    public RoiValueTests(ITestOutputHelper output)
    {
        Output = output;
    }

    [Fact]
    public void Test_PixelValues_MatchImageJ()
    {
        Core.RoiGenerator roigen = new(SampleData.TSeriesTifPath, 20, 1, false);

        // pixel values
        roigen.RedImages[0].GetValue(13, 17).Should().Be(268);
        roigen.GreenImages[0].GetValue(13, 17).Should().Be(354);
        roigen.RedImages[3].GetValue(13, 17).Should().Be(227);
        roigen.GreenImages[3].GetValue(13, 17).Should().Be(420);

        // stats
        roigen.RedImages[0].GetValues().Min().Should().Be(181);
        roigen.RedImages[0].GetValues().Max().Should().Be(8191);
        Mean(roigen.RedImages[0]).Should().BeApproximately(422.666, precision: .001);

        // crops
        Rectangle rect = new(95, 125, 30, 30);
        Channel crop = Core.Drawing.Crop(roigen.RedImages[0], rect.X, rect.Y, rect.Width, rect.Height);
        crop.Width.Should().Be(30);
        crop.Height.Should().Be(30);
        crop.GetValue(0, 0).Should().Be(318);
        crop.GetValue(2, 1).Should().Be(387);
        crop.GetValue(29, 29).Should().Be(307);
        crop.GetValue(27, 28).Should().Be(362);
        Mean(crop).Should().BeApproximately(648.622, precision: .001);
    }

    public static double Mean(Channel image)
    {
        return image.GetValues().Sum() / image.GetValues().Length;
    }

    [Fact]
    public void Test_RoiValues_MatchImageJ()
    {
        Core.RoiGenerator roigen = new(SampleData.TSeriesTifPath, 20, 1, false);
        roigen.Tracing.IsCircular = false;
        roigen.Tracing.AddRange(SampleData.TracingPoints);
        RoiCollection rois = roigen.CalculateRois(20, 5, false);

        foreach (var roi in rois.Rois)
        {
            Output.WriteLine($"makeRectangle({roi.Left}, {roi.Top}, {roi.Width}, {roi.Height}); getStatistics(area, mean); print(mean);");
        }

        double[] imagejMeansRed = { 2344.9678, 1528.31, 1021.5311, 800.6122, 734.48, 698.4911,
            726.7756, 699.0289, 571.2389, 492.1056, 475.0844, 467.2378, 430.0711, 381.6611,
            359.4244, 364.3056, 363.2989, 360.3411, 367.08, 347.5111, 324.79, 316.4989, 269.1867, 268.9411 };

        double[] imagejMeansGreen = { 2039.7056, 1275.4056, 813.4489, 662.0389, 628.0678, 597.2233,
            603.7556, 601.0078, 533.74, 499.3622, 502.8656, 505.6711, 482.5611, 440.5611, 408.3411,
            405.32, 414.2411, 405.0944, 398.1156, 391.23, 371.6356, 361.5089, 356.91, 353.9756, };

        for (int i = 0; i < rois.Rois.Length; i++)
        {
            Mean(rois.RedImages[0, i]).Should().BeApproximately(imagejMeansRed[i], .1);
            Mean(rois.GreenImages[0, i]).Should().BeApproximately(imagejMeansGreen[i], .1);
        }
    }
}
