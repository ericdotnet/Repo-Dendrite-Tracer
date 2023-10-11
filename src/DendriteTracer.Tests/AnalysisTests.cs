using FluentAssertions;

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
        RoiGenerator roigen = new(SampleData.TSeriesTifPath2, 20, 1, true);
        roigen.Tracing.AddRange(SampleData.TracingPoints2);
        roigen.Tracing.RoiRadius_Microns = 10;
        roigen.Tracing.RoiSpacing_Microns = 5;
        RoiCollection roic = roigen.CalculateRois();

        roic.GetDataByFrame(roic.Ratios).Save("TSeries-05312023-1239-2203.ratio.byFrame.csv");
        roic.GetDataByFrame(roic.RedMeans).Save("TSeries-05312023-1239-2203.red.byFrame.csv");
        roic.GetDataByFrame(roic.GreenMeans).Save("TSeries-05312023-1239-2203.green.byFrame.csv");

        roic.GetDataByRoi(roic.Ratios).Save("TSeries-05312023-1239-2203.ratio.byRoi.csv");
        roic.GetDataByRoi(roic.RedMeans).Save("TSeries-05312023-1239-2203.red.byRoi.csv");
        roic.GetDataByRoi(roic.GreenMeans).Save("TSeries-05312023-1239-2203.green.byRoi.csv");

        Core.IO.Json.SaveJson(roic, "test.json");
    }

    [Fact]
    public void Test_Json_Read()
    {
        RoiExperimentSettings r = Core.IO.Json.Load(SampleData.JsonFilePath);
        Path.GetFileName(r.TifFilePath).Should().Be("MAX_TSeries-05312023-1239-2203.tif");

        r.ImageFloor_IsEnabled.Should().BeFalse();
        r.ImageFloor_Percent.Should().Be(17);

        r.RoiIsCircular.Should().BeTrue();
        r.RoiSpacing_Microns.Should().BeApproximately(7, .01);
        r.RoiRadius_Microns.Should().BeApproximately(9, .01);

        r.Rois.Length.Should().Be(22);
        r.Rois[1].X.Should().Be(107.64232f);
        r.Rois[1].Y.Should().Be(184.21773f);
    }

    [Fact]
    public void Test_Analysis_TroublesomeFile()
    {
        RoiGenerator roigen = new(SampleData.TSeriesTifPath3, 20, 1, true);
        roigen.Tracing.AddRange(SampleData.TracingPoints2);
        roigen.Tracing.RoiRadius_Microns = 10;
        roigen.Tracing.RoiSpacing_Microns = 5;
        RoiCollection roic = roigen.CalculateRois();

        string saveAs = Path.GetFullPath("test.ijm");
        Core.IO.ImageJ.SaveIjm(roic, saveAs);
        Output.WriteLine(saveAs);
    }
}