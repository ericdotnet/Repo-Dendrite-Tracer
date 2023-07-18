namespace DendriteTracer.Tests;

public class AnalysisTests
{
    [Fact]
    public void Test_Analysis_Workflow()
    {
        double[] times = Enumerable.Range(0, 31).Select(x=>(double)x).ToArray();

        Core.AnalysisSettings settings = new(SampleData.TSeriesTifPath)
        {
            ImageSubtractionFloor_Percent = 20,
            RoiSpacing_Microns = 10,
            RoiRadius_Microns = 15,
            RoiIsCircular = true,
            PixelThresholdFloor_Percent = 20,
            PixelThreshold_Multiple = 5,
        };

        Core.PixelLocation[] points =
        {
            new(73, 186), new(90, 175), new(102.5, 159.5), new(110, 146),
            new(120, 135), new(131.5, 126.5), new(131, 113.5), new(129, 104),
            new(139.5, 89), new(149, 75.5), new(161, 65.5), new(179, 55.5),
            new(206, 39.5), new(219.5, 26), new(218, 14), new(216, 4),
        };

        Core.Analysis analysis = new(settings);
        analysis.Tracing.AddRange(points);
    }
}
