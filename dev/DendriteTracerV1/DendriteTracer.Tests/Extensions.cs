using DendriteTracer.Core;

namespace DendriteTracer.Tests;

internal static class Extensions
{
    public static void TestSave(this SciTIF.ImageRGB img, string filename)
    {
        string path = Path.GetFullPath(filename);
        Console.Write(path);
        img.Save(path);
    }

    public static void TestSave(this Bitmap bmp, string filename)
    {
        string path = Path.GetFullPath(filename);
        Console.Write(path);
        bmp.Save(path);
    }
}
