using System.Xml.Linq;

namespace ImageRatioTool;

public static class XmlFileOperations
{
    public static double[] GetSequenceTimes(string xmlFilePath)
    {
        string xmlText = File.ReadAllText(xmlFilePath);
        XDocument doc = XDocument.Parse(xmlText);
        XElement pvEl = doc.Element("PVScan")!;
        string start = pvEl.Attribute("date")!.Value.Split(" ")[0];

        DateTime[] dates = pvEl.Elements("Sequence")
            .Select(x => x.Attribute("time")!.Value)
            .Select(x => DateTime.Parse($"{start} {x}"))
            .ToArray();

        double[] seconds = dates.Select(x => x - dates.First())
            .Select(x => x.TotalSeconds)
            .ToArray();

        return seconds;
    }
}
