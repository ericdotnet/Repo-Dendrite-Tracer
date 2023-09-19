using System.Text;

namespace DendriteTracer.Core.IO;

public static class ImageJ
{
    /// <summary>
    /// Return text that can be run directly by ImageJ to select all ROIs
    /// </summary>
    public static string GetImagejMacro(RoiCollection roiCollection)
    {
        StringBuilder sb = new();
        sb.AppendLine("roiManager(\"Deselect\");");
        sb.AppendLine("roiManager(\"Delete\");");
        foreach (Roi roi in roiCollection.Rois)
        {
            string args = $"{roi.Left}, {roi.Top}, {roi.Width}, {roi.Height}";
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
