namespace DendriteTracer.Core;

public struct Color
{
    public readonly byte Red;
    public readonly byte Green;
    public readonly byte Blue;

    public Color(byte gray)
    {
        Red = gray;
        Green = gray;
        Blue = gray;
    }

    public Color(byte red, byte green, byte blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }
}

public static class Colors
{
    public static Color White => new(255, 255, 255);
    public static Color Blue => new(0, 0, 255);
    public static Color Yellow => new(255, 255, 0);
    public static Color Magenta => new(255, 0, 255);
}