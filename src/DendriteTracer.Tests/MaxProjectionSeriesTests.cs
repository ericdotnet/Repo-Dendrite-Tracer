namespace DendriteTracer.Tests;

public class MaxProjectionSeriesTests
{
    [Fact]
    public void Test_LoadTif_ProjectionSeries()
    {
        DendriteTracer.Core.MaxProjectionSeries proj = new(SampleData.TSeriesTifPath);
    }
}