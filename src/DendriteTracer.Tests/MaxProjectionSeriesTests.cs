using FluentAssertions;

namespace DendriteTracer.Tests;

public class MaxProjectionSeriesTests
{
    [Fact]
    public void Test_LoadTif_ProjectionSeries()
    {
        DendriteTracer.Core.MaxProjectionSeries proj = new(SampleData.TSeriesTifPath);
        (RasterSharp.Channel red, RasterSharp.Channel green) = proj.GetChannels(0);

        int pixelCount = red.Width * red.Height;

        double meanRed = red.GetValues().Sum() / pixelCount;
        meanRed.Should().BeApproximately(422.67, .01); // determined using ImageJ

        double meanGreen = green.GetValues().Sum() / pixelCount;
        meanGreen.Should().BeApproximately(535.77, .01); // determined using ImageJ
    }
}