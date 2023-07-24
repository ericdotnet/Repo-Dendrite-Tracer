using System.Text.Json;

namespace DendriteTracer.Core.IO;

public static class Json
{
    public static void SaveJson(RoiCollection roic, string saveAs)
    {
        using MemoryStream stream = new();
        JsonWriterOptions options = new() { Indented = true };
        using Utf8JsonWriter writer = new(stream, options);

        writer.WriteStartObject();
        writer.WriteString("Version", Core.Version.VersionString);
        writer.WriteString("Generated", DateTime.Now.ToString());
        writer.WriteNumber("RoiCount", roic.RoiCount);
        writer.WriteNumber("FrameCount", roic.FrameCount);

        writer.WriteString("Path", roic.TifFilePath);

        writer.WriteBoolean("ImageFloor_IsEnabled", roic.Settings.ImageFloor_IsEnabled);
        writer.WriteNumber("ImageFloor_Percent", roic.Settings.ImageFloor_Percent);

        writer.WriteBoolean("RoiIsCircular", roic.Settings.RoiIsCircular);
        writer.WriteNumber("RoiSpacing_Microns", roic.Settings.RoiSpacing_Microns);
        writer.WriteNumber("RoiRadius_Microns", roic.Settings.RoiRadius_Microns);

        writer.WriteBoolean("RoiThreshold_IsEnabled", roic.Settings.RoiThreshold_IsEnabled);
        writer.WriteNumber("RoiFloor_Percent", roic.Settings.RoiFloor_Percent);
        writer.WriteNumber("RoiThreshold_Multiple", roic.Settings.RoiThreshold_Multiple);

        writer.WriteStartArray("FrameTimes_min");
        roic.FrameTimes.ToList().ForEach(x => writer.WriteNumberValue(x));
        writer.WriteEndArray();

        writer.WriteStartObject("ROIs");
        for (int roiIndex = 0; roiIndex < roic.RoiCount; roiIndex++)
        {
            Roi roi = roic.Rois[roiIndex];

            // ROI dimensions
            writer.WriteStartObject($"ROI #{roiIndex + 1}");
            writer.WriteNumber("X_pixel", roi.X);
            writer.WriteNumber("Y_pixel", roi.Y);
            writer.WriteNumber("Distance_microns", roic.Positions[roiIndex]);

            // PMT red
            writer.WriteStartArray("Red");
            for (int frameIndex = 0; frameIndex < roic.FrameCount; frameIndex++)
            {
                writer.WriteNumberValue(roic.RedMeans[frameIndex, roiIndex]);
            }
            writer.WriteEndArray();

            // PMT green
            writer.WriteStartArray("Green");
            for (int frameIndex = 0; frameIndex < roic.FrameCount; frameIndex++)
            {
                writer.WriteNumberValue(roic.GreenMeans[frameIndex, roiIndex]);
            }
            writer.WriteEndArray();

            // G/R ratio
            writer.WriteStartArray("Ratio");
            for (int frameIndex = 0; frameIndex < roic.FrameCount; frameIndex++)
            {
                writer.WriteNumberValue(roic.Ratios[frameIndex, roiIndex]);
            }
            writer.WriteEndArray();

            writer.WriteEndObject();
        }
        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.Flush();
        string json = System.Text.Encoding.UTF8.GetString(stream.ToArray());

        File.WriteAllText(saveAs, json);
    }

    public static RoiExperimentSettings Load(string jsonFilePath)
    {
        using JsonDocument document = JsonDocument.Parse(File.ReadAllText(jsonFilePath));

        List<PixelLocation> points = new();

        foreach (var e in document.RootElement.GetProperty("ROIs").EnumerateObject())
        {
            float x = (float)e.Value.GetProperty("X_pixel").GetDouble();
            float y = (float)e.Value.GetProperty("Y_pixel").GetDouble();
            points.Add(new(x, y));
        }

        return new RoiExperimentSettings()
        {
            TifFilePath = document.RootElement.GetProperty("Path").GetString()!,

            ImageFloor_IsEnabled = document.RootElement.GetProperty("ImageFloor_IsEnabled").GetBoolean(),
            ImageFloor_Percent = document.RootElement.GetProperty("ImageFloor_Percent").GetDouble(),

            RoiIsCircular = document.RootElement.GetProperty("RoiIsCircular").GetBoolean(),
            RoiSpacing_Microns = document.RootElement.GetProperty("RoiSpacing_Microns").GetDouble(),
            RoiRadius_Microns = document.RootElement.GetProperty("RoiRadius_Microns").GetDouble(),

            RoiThreshold_IsEnabled = document.RootElement.GetProperty("RoiThreshold_IsEnabled").GetBoolean(),
            RoiFloor_Percent = document.RootElement.GetProperty("RoiFloor_Percent").GetDouble(),
            RoiThreshold_Multiple = document.RootElement.GetProperty("RoiThreshold_Multiple").GetDouble(),

            Rois = points.ToArray(),
        };
    }
}
