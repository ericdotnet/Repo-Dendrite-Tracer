using FluentAssertions;

namespace DendriteTracer.Tests;

public class SampleData
{
    public static readonly string TSeriesTifPath = Path.GetFullPath("SampleData/MAX_TSeries-04132023-1214-2165.tif");
    public static readonly string TSeriesXmlPath = Path.GetFullPath("SampleData/TSeries-04132023-1214-2165.xml");

    [Fact]
    public void Test_Files_exist()
    {
        Console.WriteLine(TSeriesTifPath);
        File.Exists(TSeriesTifPath).Should().BeTrue();
        File.Exists(TSeriesTifPath).Should().BeTrue();
    }
}
