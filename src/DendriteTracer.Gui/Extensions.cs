namespace DendriteTracer.Gui;

public static class Extensions
{
    public static Bitmap ToBitmap(this byte[] bytes)
    {
        using MemoryStream ms = new(bytes);
        Bitmap bmp = new(ms);
        return bmp;
    }
}
