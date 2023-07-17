using System.Text.Json;
using System.Text;

namespace ImageRatioTool;

public class SquareRoiCollection
{
    public string Source { get; }
    public int Width { get; }
    public int Height { get; }
    public int Count => RoiCenters.Count;

    public int Radius { get; } = 5;

    public List<FractionalPoint> RoiCenters { get; } = new();

    public List<FractionalPoint> MousePoints { get; } = new();

    public List<double> FrameTimes { get; } = new();
    public List<double[]> AfusByFrame { get; } = new();


    public SquareRoiCollection(string source, int width, int height)
    {
        Source = source;
        Width = width;
        Height = height;
    }

    public void Save(string csvFile)
    {
        string saveAsCSV = Path.GetFullPath(csvFile);
        File.WriteAllText(saveAsCSV, GetCSV(AfusByFrame));
        Console.WriteLine(saveAsCSV);

        string saveAsJSON = saveAsCSV + ".json";
        File.WriteAllText(saveAsJSON, GetJson());
        Console.WriteLine(saveAsJSON);
    }

    public string GetCSV(List<double[]> afusByFrame)
    {
        if (FrameTimes.Count != AfusByFrame.Count)
            throw new InvalidOperationException($"{nameof(FrameTimes)} should be same length as {nameof(afusByFrame)}");

        int frameCount = afusByFrame.Count;
        int roiCount = afusByFrame.First().Length;

        StringBuilder sb = new();

        List<string> columnNames = new() { "Time" };
        for (int i = 0; i < frameCount; i++)
        {
            columnNames.Add($"ROI {i + 1}");
        }
        sb.AppendLine(string.Join(", ", columnNames));

        for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
        {
            string[] values = afusByFrame[frameIndex].Select(x => x.ToString()).ToArray();
            string line = FrameTimes[frameIndex].ToString() + ", " + string.Join(", ", values);
            sb.AppendLine(line);
        }

        return sb.ToString();
    }

    public string GetJson()
    {
        using MemoryStream stream = new();
        JsonWriterOptions options = new() { Indented = true };
        using Utf8JsonWriter writer = new(stream, options);

        writer.WriteStartObject();
        writer.WriteString("type", "Square ROI Collection");
        writer.WriteString("DateTime", DateTime.Now);
        writer.WriteString(nameof(Source), Source);
        writer.WriteNumber(nameof(Width), Width);
        writer.WriteNumber(nameof(Height), Height);

        writer.WriteStartArray("MousePoints");
        foreach (FractionalPoint point in MousePoints)
        {
            writer.WriteStartObject();
            writer.WriteNumber("X", point.X);
            writer.WriteNumber("Y", point.Y);
            writer.WriteEndObject();
        }
        writer.WriteEndArray();

        writer.WriteStartArray("ROIs");
        foreach (FractionalPoint point in RoiCenters)
        {
            writer.WriteStartObject();
            writer.WriteNumber("X", point.X);
            writer.WriteNumber("Y", point.Y);
            writer.WriteNumber("R", Radius);
            writer.WriteEndObject();
        }
        writer.WriteEndArray();

        writer.WriteEndObject();

        writer.Flush();
        string json = Encoding.UTF8.GetString(stream.ToArray());

        return json;
    }
}
