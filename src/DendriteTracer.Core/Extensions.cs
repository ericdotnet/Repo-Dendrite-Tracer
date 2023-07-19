using System.Drawing;

namespace DendriteTracer.Core;
internal static class Extensions
{
    public static Bitmap ToSDBitmap(this byte[] bytes)
    {
        using MemoryStream ms = new(bytes);
        Bitmap bmp = new(ms);
        return bmp;
    }

    public static Bitmap ToSDBitmap(this RasterSharp.Image img)
    {
        return img.GetBitmapBytes().ToSDBitmap();
    }
}
