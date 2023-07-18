using System.Data;
using System.Text;

namespace DendriteTracer.Tests;

public class AnalysisTests
{
    [Fact]
    public void Test_Analysis_Workflow()
    {
        double[] times = Enumerable.Range(0, 31).Select(x => (double)x).ToArray();

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

        var dataByFrame = analysis.GetRoiDataByFrame();

        double[,] dffValues = new double[analysis.FrameCount, analysis.RoiCount];
        for (int frameIndex = 0; frameIndex < analysis.FrameCount; frameIndex++)
        {
            double threshold = 0; // TODO
            var frameCurves = dataByFrame[frameIndex].GetCurves(threshold);
            for (int roiIndex = 0; roiIndex < analysis.RoiCount; roiIndex++)
            {
                dffValues[frameIndex, roiIndex] = frameCurves.ratios[roiIndex];
            }
        }

        StringBuilder sb = new();

        sb.Append($"\"Time\"\t");
        for (int i = 0; i < analysis.RoiCount; i++)
        {
            sb.Append($"\"{10 * i} µm\"\t");
        }
        sb.AppendLine();

        string saveAs = Path.GetFullPath("test.csv");
        for (int i = 0; i < analysis.FrameCount; i++)
        {
            sb.Append($"{i}\t");

            for (int j = 0; j < analysis.RoiCount; j++)
            {
                sb.Append($"{dffValues[i, j]}\t");
            }

            sb.AppendLine();
        }
        File.WriteAllText(saveAs, sb.ToString());
        Console.Write(saveAs);
    }
}
