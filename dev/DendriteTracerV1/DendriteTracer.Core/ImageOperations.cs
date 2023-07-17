namespace DendriteTracer.Core;

public static class ImageOperations
{
    public static Bitmap MakeBitmap(SciTIF.Image red)
    {
        red.AutoScale();

        Bitmap bmp = new(red.Width, red.Height);

        for (int y = 0; y < red.Height; y++)
        {
            for (int x = 0; x < red.Width; x++)
            {
                byte r = red.GetPixelByte(x, y, true);
                Color c = new(r, r, r);

                bmp.SetPixel(x, y, c);
            }
        }

        return bmp;
    }

    public static Bitmap MakeBitmap(SciTIF.Image red, SciTIF.Image green)
    {
        red.AutoScale();
        green.AutoScale();

        Bitmap bmp = new(red.Width, red.Height);

        for (int y = 0; y < red.Height; y++)
        {
            for (int x = 0; x < red.Width; x++)
            {
                byte r = red.GetPixelByte(x, y, true);
                byte g = green.GetPixelByte(x, y, true);
                Color c = new(r, g, r);

                bmp.SetPixel(x, y, c);
            }
        }

        return bmp;
    }
}
