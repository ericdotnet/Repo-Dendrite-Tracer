namespace DendriteTracer.Core;

/// <summary>
/// The center of an ROI with a radius, all in pixel units
/// </summary>
public struct Roi
{
    public float X { get; }
    public float Y { get; }
    public float R { get; }
    public bool IsCircular { get; }

    public float Left => X - R;
    public float Right => X + R;
    public float Top => Y - R;
    public float Bottom => Y + R;
    public float Width => R * 2;
    public float Height => R * 2;
    public string Shape => IsCircular ? "Circle" : "Square";

    public Roi(float x, float y, float r, bool isCircular)
    {
        X = x;
        Y = y;
        R = r;
        IsCircular = isCircular;
    }

    public override string ToString()
    {
        return $"ROI: X={X}, Y={Y}, R={R}, {Shape}";
    }
}
