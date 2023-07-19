namespace DendriteTracer.Core;

/// <summary>
/// Location in pixel space
/// </summary>
public struct PixelLocation
{
    public readonly float X;
    public readonly float Y;

    public PixelLocation(double x, double y)
    {
        X = (float)x;
        Y = (float)y;
    }

    public PixelLocation(float x, float y)
    {
        X = x;
        Y = y;
    }
}
