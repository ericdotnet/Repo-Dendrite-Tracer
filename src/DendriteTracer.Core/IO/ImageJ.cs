using System.Text;

namespace DendriteTracer.Core.IO;

public static class ImageJ
{
    /// <summary>
    /// Return text that can be run directly by ImageJ to select all ROIs
    /// </summary>
    public static string GetImagejMacro(RoiCollection roiCollection)
    {
        string safePath = roiCollection.TifFilePath.Replace("\\", "/");
        StringBuilder sb = new();
        sb.AppendLine($"open(\"{safePath}\");");
        sb.AppendLine("roiManager(\"reset\");");
        foreach (Roi roi in roiCollection.Rois)
        {
            string args = $"{(int)roi.Left}, {(int)roi.Top}, {(int)roi.Width}, {(int)roi.Height}";
            string func = roi.IsCircular ? "makeOval" : "makeRectangle";
            sb.AppendLine($"{func}({args}); roiManager(\"Add\");");
        }
        sb.AppendLine("roiManager(\"Show All with labels\");");
        return sb.ToString();
    }

    /// <summary>
    /// Save an ImageJ macro file that can be run directly by ImageJ to select all ROIs
    /// </summary>
    public static void SaveIjm(RoiCollection roiCollection, string saveAs)
    {
        File.WriteAllText(saveAs, GetImagejMacro(roiCollection));
    }
}
