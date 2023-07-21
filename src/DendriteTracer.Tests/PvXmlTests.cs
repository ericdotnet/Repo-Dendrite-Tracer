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
        double[] expectedTimes = Enumerable.Range(0, 30).Select(x => (double)x).ToArray();
        PvXml.GetFrameTimes(xmlFilePath).Should().BeEquivalentTo(expectedTimes);
    }
}
