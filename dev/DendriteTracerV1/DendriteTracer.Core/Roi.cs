namespace DendriteTracer.Core;

public struct Roi
{
    public int X { get; }
    public int Y { get; }
    public int Radius { get; }

    public readonly Rectangle Rectangle => new(X, Y, Radius);

    public Roi(Pixel center, int radius)
    {
        X = center.X;
        Y = center.Y;
        Radius = radius;
    }

    public Roi(int x, int y, int radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }
}
