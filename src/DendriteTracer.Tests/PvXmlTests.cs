using DendriteTracer.Core.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace DendriteTracer.Tests;

public class PvXmlTests
{
    private readonly ITestOutputHelper Output;

    public PvXmlTests(ITestOutputHelper output)
    {
        Output = output;
    }

    [Fact]
    public void Test_PvXML_Locate()
    {
        string xmlFilePath = Core.IO.PvXml.Locate(SampleData.TSeriesTifPath);
        Path.GetFileName(xmlFilePath).Should().Be("TSeries-04132023-1214-2165.xml");
    }

    [Fact]
    public void Test_PvXML_MicronsPerPixel()
    {
        string xmlFilePath = Core.IO.PvXml.Locate(SampleData.TSeriesTifPath);
        PvXml.GetMicronsPerPixel(xmlFilePath).Should().Be(1.17879356364206);
    }

    [Fact]
    public void Test_PvXML_FrameTimes()
    {
        string xmlFilePath = Core.IO.PvXml.Locate(SampleData.TSeriesTifPath);


        Output.WriteLine(string.Join(", ", PvXml.GetFrameTimes(xmlFilePath)));

        double[] expectedTimes =
        {
             0, 59.905, 119.904, 179.905, 239.904, 299.904, 359.905, 419.904,
            479.905, 539.905, 599.905, 659.905, 719.904, 779.905, 839.905,
            899.905, 959.905, 1019.904, 1079.905, 1139.905, 1199.909, 1259.905,
            1319.904, 1379.906, 1439.904, 1499.905, 1559.905, 1619.905, 1679.905,
            1739.905, 1799.905,
        };

        PvXml.GetFrameTimes(xmlFilePath).Should().BeEquivalentTo(expectedTimes);
    }
}
