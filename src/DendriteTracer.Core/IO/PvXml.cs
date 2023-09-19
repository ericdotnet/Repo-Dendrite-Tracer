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

        string xmlInParentFolder = Path.Combine(Path.GetDirectoryName(tifFolder)!, xmlFilename);
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

    public static double[] GetFrameTimes(string xmlFilePath)
    {
        string xmlText = File.ReadAllText(xmlFilePath);
        XDocument doc = XDocument.Parse(xmlText);
        double[] sequenceFirstFrameTimes = doc.Element("PVScan")!
            .Elements("Sequence")!
            .Select(x => x.Elements("Frame").FirstOrDefault())
            .Skip(1)
            .Select(x => x is null ? -1 : double.Parse(x.Attribute("absoluteTime")!.Value))
            .ToArray();

        double framePeriod = sequenceFirstFrameTimes[1] - sequenceFirstFrameTimes[0];
        for (int i = 1; i < sequenceFirstFrameTimes.Length; i++)
        {
            if (sequenceFirstFrameTimes[i] < 0)
            {
                sequenceFirstFrameTimes[i] = sequenceFirstFrameTimes[i - 1] + framePeriod;
            }
        }

        double[] frameTimes = sequenceFirstFrameTimes
            .Select(x => x - sequenceFirstFrameTimes.First())
            .Select(x => Math.Round(x) / 60.0)
            .ToArray();

        return frameTimes;
    }
}
