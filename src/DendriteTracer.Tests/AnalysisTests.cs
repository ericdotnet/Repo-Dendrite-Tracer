namespace DendriteTracer.Tests;

public class AnalysisTests
{
    private readonly ITestOutputHelper Output;

    public AnalysisTests(ITestOutputHelper output)
    {
        Output = output;
    }

    [Fact]
    public void Test_Analysis()
    {
        RoiGenerator roigen = new(SampleData.TSeriesTifPath2);
        roigen.Tracing.AddRange(SampleData.TracingPoints2);
        roigen.Tracing.RoiRadius_Microns = 10;
        roigen.Tracing.RoiSpacing_Microns = 5;
        RoiCollection roic = roigen.CalculateRois(0, 0);

        roic.GetDataByFrame(roic.Ratios).Save("TSeries-05312023-1239-2203.ratio.byFrame.csv");
        roic.GetDataByFrame(roic.RedMeans).Save("TSeries-05312023-1239-2203.red.byFrame.csv");
        roic.GetDataByFrame(roic.GreenMeans).Save("TSeries-05312023-1239-2203.green.byFrame.csv");

        roic.GetDataByRoi(roic.Ratios).Save("TSeries-05312023-1239-2203.ratio.byRoi.csv");
        roic.GetDataByRoi(roic.RedMeans).Save("TSeries-05312023-1239-2203.red.byRoi.csv");
        roic.GetDataByRoi(roic.GreenMeans).Save("TSeries-05312023-1239-2203.green.byRoi.csv");
    }
}
