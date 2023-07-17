using System.Runtime.Intrinsics.Arm;

namespace DendriteTracer.Core;

public class DendritePath
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    public readonly List<Pixel> Points = new();
    public int Count => Points.Count;

    public DendritePath(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void Resize(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void Add(Pixel px)
    {
        Add(px.X, px.Y);
    }

    public void Add(int x, int y)
    {
        if (x < 0 || x >= Width)
            throw new InvalidOperationException($"X ({x}) outside image width ({Width})");

        if (y < 0 || y >= Height)
            throw new InvalidOperationException($"X ({y}) outside image width ({Height})");

        Points.Add(new Pixel(x, y));
    }

    public void Clear()
    {
        Points.Clear();
    }

    public Pixel[] GetEvenlySpacedPoints(double spacing)
    {
        return GetSubPoints(Points, spacing);
    }

    public void Draw(Bitmap bmp)
    {
        bmp.DrawLines(Points, Colors.White);

        foreach (Pixel px in Points)
        {
            Rectangle rect = new(px, 2);
            bmp.DrawRect(rect, Colors.Yellow);
        }
    }

    public string GetPointsString()
    {
        return string.Join(" ", Points.Select(x => $"{x.X},{x.Y};"));
    }

    public void LoadFromString(string text)
    {
        Points.Clear();
        foreach (string line in text.Split(";"))
        {
            string[] parts = line.Split(",");
            if (parts.Length != 2)
                continue;
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            Pixel px = new(x, y);
            Points.Add(px);
        }
    }

    /// <summary>
    /// Walk along a multi-point line and place evenly spaced subpoints along the way.
    /// </summary>
    private static Pixel[] GetSubPoints(IEnumerable<Pixel> points, double spacing)
    {
        List<Pixel> subPoints = new() { points.First() };
        double nextSetback = 0;
        Pixel lastPoint = points.First();
        foreach (Pixel point in points.Skip(1))
        {
            (List<Pixel> segmentPoints, double setback) = GetSubPoints(lastPoint, point, spacing, nextSetback);
            nextSetback = setback;
            subPoints.AddRange(segmentPoints);
            lastPoint = point;
        }
        return subPoints.ToArray();
    }

    /// <summary>
    /// Walk from point 1 to point 2 and place new subpoints along the way.
    /// The first subpoint will be set back by the given amount.
    /// The distance remaining between the last subpoint and point 2 is returned.
    /// </summary>
    private static (List<Pixel> points, double nextSetback) GetSubPoints(Pixel pt1, Pixel pt2, double spacing, double setback)
    {
        double dx = pt2.X - pt1.X;
        double dy = pt2.Y - pt1.Y;
        double distanceBetweenPoints = Math.Sqrt(dx * dx + dy * dy);
        double angle = Math.Atan(dy / dx);
        if (dx < 0)
            angle += Math.PI;

        List<Pixel> points = new();
        double travelled = spacing - setback;
        while (travelled <= distanceBetweenPoints)
        {
            double x = pt1.X + travelled * Math.Cos(angle);
            double y = pt1.Y + travelled * Math.Sin(angle);
            points.Add(new((int)x, (int)y));
            travelled += spacing;
        }

        double interPointTotal = (points.Count - 1) * spacing;
        double totalDistanceTravelled = spacing - setback + interPointTotal;
        double nextSetback = distanceBetweenPoints - totalDistanceTravelled;

        return (points, nextSetback);
    }

    public Roi[] GetRois(double spacing, int radius)
    {
        return GetEvenlySpacedPoints(spacing)
            .Select(x => new Roi(x, radius))
            .ToArray();
    }
}