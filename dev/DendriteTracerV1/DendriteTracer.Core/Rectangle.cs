namespace DendriteTracer.Core;

/// <summary>
/// Pixel rectangle with inclusive edges
/// </summary>
public struct Rectangle
{
    public readonly int XMin;
    public readonly int XMax;
    public readonly int YMin;
    public readonly int YMax;

    public int Top => YMin;
    public int Bottom => YMax;
    public int Left => XMin;
    public int Right => XMax;
    public int Width => XMax - XMin;
    public int Height => YMax - YMin;

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        XMin = Math.Min(x1, x2);
        XMax = Math.Max(x1, x2);
        YMin = Math.Min(y1, y2);
        YMax = Math.Max(y1, y2);
    }

    public Rectangle(int x, int y, int r)
    {
        XMin = x - r;
        XMax = x + r;
        YMin = y - r;
        YMax = y + r;
    }

    public Rectangle(Pixel px, int r)
    {
        XMin = px.X - r;
        XMax = px.X + r;
        YMin = px.Y - r;
        YMax = px.Y + r;
    }
}