namespace DendriteTracer.Core;

public struct Roi
{
    public float X { get; }
    public float Y { get; }
    public float R { get; }

    public Roi(float x, float y, float r)
    {
        X = x;
        Y = y;
        R = r;
    }
}
