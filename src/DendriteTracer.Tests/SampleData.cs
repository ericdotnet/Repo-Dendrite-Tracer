using DendriteTracer.Core;
using FluentAssertions;

namespace DendriteTracer.Tests;

public class SampleData
{
    public static readonly string TSeriesTifPath = Path.GetFullPath("SampleData/MAX_TSeries-04132023-1214-2165.tif");
    public static readonly string TSeriesXmlPath = Path.GetFullPath("SampleData/TSeries-04132023-1214-2165.xml");

    public static readonly Core.PixelLocation[] TracingPoints =
    {
        new(73, 186), new(90, 175), new(102.5, 159.5), new(110, 146),
        new(120, 135), new(131.5, 126.5), new(131, 113.5), new(129, 104),
        new(139.5, 89), new(149, 75.5), new(161, 65.5), new(179, 55.5),
        new(206, 39.5), new(219.5, 26), new(218, 14), new(216, 4),
    };

    public static readonly Tracing Tracing = GetTracing();

    private static Tracing GetTracing()
    {
        Tracing t = new(512, 512, 1.17879356364206f);
        t.AddRange(TracingPoints);
        return t;
    }

    [Fact]
    public void Test_Files_exist()
    {
        Console.WriteLine(TSeriesTifPath);
        File.Exists(TSeriesTifPath).Should().BeTrue();
        File.Exists(TSeriesTifPath).Should().BeTrue();
    }
}
