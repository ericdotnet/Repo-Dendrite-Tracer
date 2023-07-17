namespace ImageRatioTool;

/// <summary>
/// Represents a point on an image using fractional units (0-1).
/// 
/// </summary>
public struct FractionalPoint
{
    public double X; // left of image is 0
    public double Y; // top of image is 0

    public FractionalPoint(double x, double y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"{X:N4}, {Y:N4}";
    }

    public Point ToPoint(int width, int height)
    {
        return new Point(
            x: (int)(width * X),
            y: (int)(height * Y));
    }
}
