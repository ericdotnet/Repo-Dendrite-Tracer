namespace ImageRatioTool;

public static class LineOperations
{
    /// <summary>
    /// Walk along a multi-point line and place evenly spaced subpoints along the way.
    /// </summary>
    public static PointF[] GetSubPoints(Point[] points, double spacing)
    {
        List<PointF> subPoints = new();
        double nextSetback = 0;
        for (int i = 1; i < points.Length; i++)
        {
            (PointF[] segmentPoints, double setback) = GetSubPoints(points[i - 1], points[i], spacing, nextSetback);
            nextSetback = setback;
            subPoints.AddRange(segmentPoints);
        }
        return subPoints.ToArray();
    }

    /// <summary>
    /// Walk from point 1 to point 2 and place new subpoints along the way.
    /// The first subpoint will be set back by the given amount.
    /// The distance remaining between the last subpoint and point 2 is returned.
    /// </summary>
    private static (PointF[] points, double nextSetback) GetSubPoints(Point pt1, Point pt2, double spacing, double setback)
    {
        double dx = pt2.X - pt1.X;
        double dy = pt2.Y - pt1.Y;
        double distanceBetweenPoints = Math.Sqrt(dx * dx + dy * dy);
        double angle = Math.Atan(dy / dx);
        if (dx < 0)
            angle += Math.PI;

        List<PointF> points = new();
        double travelled = spacing - setback;
        while (travelled <= distanceBetweenPoints)
        {
            double x = pt1.X + travelled * Math.Cos(angle);
            double y = pt1.Y + travelled * Math.Sin(angle);
            points.Add(new((float)x, (float)y));
            travelled += spacing;
        }

        double interPointTotal = (points.Count - 1) * spacing;
        double totalDistanceTravelled = spacing - setback + interPointTotal;
        double nextSetback = distanceBetweenPoints - totalDistanceTravelled;

        return (points.ToArray(), nextSetback);
    }
}
