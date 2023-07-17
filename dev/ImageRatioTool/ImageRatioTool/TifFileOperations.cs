using BitMiracle.LibTiff.Classic;

namespace ImageRatioTool;

public static class TifFileOperations
{
    public static double GetMicronsPerPixel(string tifFilePath)
    {
        using Tiff image = Tiff.Open(tifFilePath, "r");
        return 1.0 / (float)image.GetField(TiffTag.XRESOLUTION).First().Value;
    }
}
