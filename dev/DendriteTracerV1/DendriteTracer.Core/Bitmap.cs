using System.Drawing;
using System.Security.Cryptography;

namespace DendriteTracer.Core;

public class Bitmap
{
    public readonly int Width;
    public readonly int Height;

    private readonly byte[] ImageBytes;

    public Bitmap(int width, int height)
    {
        Width = width;
        Height = height;
        ImageBytes = new byte[width * height * 4];
    }

    public Bitmap Clone()
    {
        Bitmap bmp = new(Width, Height);
        bmp.SetImageBytes(ImageBytes);
        return bmp;
    }

    public Bitmap Crop(Rectangle rect, bool constrain = true)
    {
        Bitmap bmp = new(rect.Width, rect.Height);

        int xMin = rect.XMin;
        int xMax = rect.XMax;
        int yMin = rect.YMin;
        int yMax = rect.YMax;

        if (constrain)
        {
            if (xMin < 0)
                xMin = 0;
            if (xMax > Width - 1)
                xMax = Width - 1;
            if (yMin < 0) 
                yMin = 0;
            if (yMax > Height - 1)
                yMax = Height - 1;
        }

        for (int y = yMin; y <= yMax; y++)
        {
            for (int x = xMin; x <= xMax; x++)
            {
                Color c = GetPixel(x, y);
                bmp.SetPixel(x - xMin, y - yMin, c);
            }
        }
        return bmp;
    }

    public void SetImageBytes(byte[] bytes)
    {
        if (bytes.Length != ImageBytes.Length)
            throw new ArgumentException("different lengths");
        Array.Copy(bytes, 0, ImageBytes, 0, bytes.Length);
    }

    public void SetPixel(int x, int y, Color c)
    {
        if (x < 0 || x >= Width)
            return;

        if (y < 0 || y >= Height)
            return;

        int offset = ((Height - y - 1) * Width + x) * 4;
        ImageBytes[offset + 0] = c.Blue;
        ImageBytes[offset + 1] = c.Green;
        ImageBytes[offset + 2] = c.Red;
    }

    public Color GetPixel(int x, int y)
    {
        int offset = ((Height - y - 1) * Width + x) * 4;
        byte b = ImageBytes[offset + 0];
        byte g = ImageBytes[offset + 1];
        byte r = ImageBytes[offset + 2];
        return new Color(r, b, b);
    }

    public void FillRect(Rectangle rect, Color color)
    {
        for (int y = rect.YMin; y < rect.YMax; y++)
        {
            for (int x = rect.XMin; x < rect.XMax; x++)
            {
                SetPixel(x, y, color);
            }
        }
    }

    public void DrawRect(Rectangle rect, Color color)
    {
        DrawLine(rect.Left, rect.Top, rect.Right, rect.Top, color);
        DrawLine(rect.Right, rect.Top, rect.Right, rect.Bottom, color);
        DrawLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom, color);
        DrawLine(rect.Left, rect.Bottom, rect.Left, rect.Top, color);
    }

    public void DrawLine(int x1, int y1, int x2, int y2, Color color)
    {
        int xMin = Math.Min(x1, x2);
        int xMax = Math.Max(x1, x2);
        int yMin = Math.Min(y1, y2);
        int yMax = Math.Max(y1, y2);

        int xSpan = xMax - xMin;
        int ySpan = yMax - yMin;

        if (xSpan == 0)
        {
            for (int y = yMin; y <= yMax; y++)
                SetPixel(xMin, y, color);
        }
        else if (ySpan == 0)
        {
            for (int x = xMin; x <= xMax; x++)
                SetPixel(x, yMin, color);
        }
        else if (ySpan > xSpan)
        {
            for (int y = yMin; y <= yMax; y++)
            {
                double frac = (y - yMin) / (double)ySpan;
                if (y2 < y1)
                    frac = 1 - frac;
                int x = (int)(frac * xSpan + xMin);
                SetPixel(x, y, color);
            }
        }
        else
        {
            for (int x = xMin; x <= xMax; x++)
            {
                double frac = (x - xMin) / (double)xSpan;
                if (x2 < x1)
                    frac = 1 - frac;
                int y = (int)(frac * ySpan + yMin);
                SetPixel(x, y, color);
            }
        }
    }

    public void DrawLine(Pixel px1, Pixel px2, Color color)
    {
        DrawLine(px1.X, px1.Y, px2.X, px2.Y, color);
    }

    public void DrawLines(IEnumerable<Pixel> pixels, Color color)
    {
        Pixel lastPixel = pixels.First();
        foreach (Pixel pixel in pixels.Skip(1))
        {
            DrawLine(lastPixel, pixel, color);
            lastPixel = pixel;
        }
    }

    public byte[] GetBitmapBytes()
    {
        const int imageHeaderSize = 54;
        byte[] bmpBytes = new byte[ImageBytes.Length + imageHeaderSize];
        bmpBytes[0] = (byte)'B';
        bmpBytes[1] = (byte)'M';
        bmpBytes[14] = 40;
        Array.Copy(BitConverter.GetBytes(bmpBytes.Length), 0, bmpBytes, 2, 4);
        Array.Copy(BitConverter.GetBytes(imageHeaderSize), 0, bmpBytes, 10, 4);
        Array.Copy(BitConverter.GetBytes(Width), 0, bmpBytes, 18, 4);
        Array.Copy(BitConverter.GetBytes(Height), 0, bmpBytes, 22, 4);
        Array.Copy(BitConverter.GetBytes(32), 0, bmpBytes, 28, 2);
        Array.Copy(BitConverter.GetBytes(ImageBytes.Length), 0, bmpBytes, 34, 4);
        Array.Copy(ImageBytes, 0, bmpBytes, imageHeaderSize, ImageBytes.Length);
        return bmpBytes;
    }

    public void Multiply(double mult)
    {
        for (int i = 0; i < ImageBytes.Length; i++)
            ImageBytes[i] = (byte)(ImageBytes[i] * mult);
    }

    public void Save(string filename)
    {
        byte[] bytes = GetBitmapBytes();
        File.WriteAllBytes(filename, bytes);
    }
}
