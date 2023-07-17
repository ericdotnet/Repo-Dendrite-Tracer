namespace ImageRatioTool.Tests;

internal static class SampleData
{
    static readonly Random Rand = new();

    public static FractionalPoint[] RandomPoints(int count)
    {
        FractionalPoint[] points = new FractionalPoint[count];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new FractionalPoint
            {
                X = Rand.NextDouble(),
                Y = Rand.NextDouble(),
            };
        }

        return points;
    }

    public static List<double[]> RandomAfuCurves(int frameCount, int roiCount)
    {
        List<double[]> afusByFrame = new();

        for (int i = 0; i < frameCount; i++)
        {
            double[] afus = Enumerable.Range(0, roiCount)
                .Select(x => Rand.NextDouble() * 1024)
                .ToArray();

            afusByFrame.Add(afus);
        }

        return afusByFrame;
    }
}
