namespace DendriteTracer.Core;

/// <summary>
/// The center of an ROI with a radius, all in pixel units
/// </summary>
public struct Roi
{
    public float X { get; }
    public float Y { get; }
    public float R { get; }
    public float Left => X - R;
    public float Right => X + R;
    public float Top => Y - R;
    public float Bottom => Y + R;
    public float Width => R * 2;
    public float Height => R * 2;

    public Roi(float x, float y, float r)
    {
        X = x;
        Y = y;
        R = r;
    }
}
