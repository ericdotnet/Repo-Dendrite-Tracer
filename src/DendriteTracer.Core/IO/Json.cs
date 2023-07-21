namespace DendriteTracer.Core.IO;

public static class Json
{
    public static void SaveJson(RoiCollection roic, string saveAs)
    {
        using MemoryStream stream = new();
        System.Text.Json.JsonWriterOptions options = new() { Indented = true };
        using System.Text.Json.Utf8JsonWriter writer = new(stream, options);

        writer.WriteStartObject();
        writer.WriteString("Version", Core.Version.VersionString);
        writer.WriteString("Generated", DateTime.Now.ToString());
        writer.WriteString("Path", roic.TifFilePath);
        writer.WriteNumber("RoiCount", roic.RoiCount);
        writer.WriteNumber("FrameCount", roic.FrameCount);
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
            writer.WriteString("Shape", roi.Shape);

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
}
