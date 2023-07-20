using System.Xml.Linq;
using System.Xml.XPath;

namespace DendriteTracer.Core.IO;

public static class PvXml
{
    public static string Locate(string tifFilePath)
    {
        tifFilePath = Path.GetFullPath(tifFilePath);

        string basename = Path.GetFileNameWithoutExtension(tifFilePath);

        if (basename.StartsWith("MAX_"))
        {
            basename = basename[4..];
        };

        string xmlFilename = basename + ".xml";

        string tifFolder = Path.GetDirectoryName(tifFilePath)!;

        string xmlInTifFolder = Path.Combine(tifFolder, xmlFilename);
        if (File.Exists(xmlInTifFolder))
            return xmlInTifFolder;

        string xmlInParentFolder = Path.Combine(Path.GetDirectoryName(tifFolder), xmlFilename);
        if (File.Exists(xmlInParentFolder))
            return xmlInParentFolder;

        throw new FileNotFoundException($"XML file for {tifFilePath}");
    }

    public static double GetMicronsPerPixel(string xmlFilePath)
    {
        string xmlText = File.ReadAllText(xmlFilePath);
        XDocument doc = XDocument.Parse(xmlText);

        string micronsPerPixelValue = doc.Element("PVScan")!
            .Element("PVStateShard")!
            .Elements("PVStateValue")!
            .Where(x => x.Attribute("key") is not null)
            .Where(x => x.Attribute("key")!.Value == "micronsPerPixel")
            .Single()
            .Elements()
            .First()
            .Attribute("value")!.Value;

        return double.Parse(micronsPerPixelValue);
    }

    public static double[] GetFrameTimes(string xmlFilePath, int precision = 3)
    {
        string xmlText = File.ReadAllText(xmlFilePath);
        XDocument doc = XDocument.Parse(xmlText);
        var sequenceFirstFrameTimes = doc.Element("PVScan")!
            .Elements("Sequence")!
            .Select(x => x.Elements("Frame").First())
            .Select(x => double.Parse(x.Attribute("absoluteTime")!.Value))
            .ToArray();

        double[] frameTimes = sequenceFirstFrameTimes
            .Select(x => x - sequenceFirstFrameTimes.First())
            .Select(x => Math.Round(x, precision))
            .ToArray();

        return frameTimes;
    }
}
