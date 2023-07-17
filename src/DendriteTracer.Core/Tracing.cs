namespace DendriteTracer.Core;

public class Tracing
{
    private readonly List<PixelLocation> TracePixels = new();

    public int Width { get; }
    public int Height { get; }

    public Tracing(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void Clear()
    {
        TracePixels.Clear();
    }

    public void Add(float x, float y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            throw new ArgumentException("outside image area");

        TracePixels.Add(new PixelLocation(x, y));
    }

    public void Add(PixelLocation pixel)
    {
        Add(pixel.X, pixel.Y);
    }

    public PixelLocation[] GetPixels()
    {
        return TracePixels.ToArray();
    }

    public string GetPointsString()
    {
        return string.Join(", ", GetPixels().Select(p => $"({p.X}, {p.Y})"));
    }

    /// <summary>
    /// Return a collection of ROIs evenly-spaced along the trace
    /// </summary>
    public Roi[] GetEvenlySpacedRois(float spacing, float radius)
    {
        List<Roi> rois = new();

        double nextSetback = 0;

        for (int i = 1; i < TracePixels.Count; i++)
        {
            (PixelLocation[] segmentPoints, double setback) = GetSubPoints(TracePixels[i - 1], TracePixels[i], spacing, nextSetback);
            nextSetback = setback;
            Roi[] segmentRois = segmentPoints.Select(pt => new Roi(pt.X, pt.Y, radius)).ToArray();
            rois.AddRange(segmentRois);
        }

        // TODO: more clearly warn if ROIs in the middle are missing

        return rois.Where(RoiIsFullyInsideImage).ToArray();
    }

    private bool RoiIsFullyInsideImage(Roi roi)
    {
        if (roi.Left < 0)
            return false;
        if (roi.Right >= Width)
            return false;
        if (roi.Top < 0)
            return false;
        if (roi.Bottom >= Height)
            return false;
        return true;
    }

    /// <summary>
    /// Walk from point 1 to point 2 and place new subpoints along the way.
    /// The first subpoint will be set back by the given amount.
    /// The distance remaining between the last subpoint and point 2 is returned.
    /// </summary>
    private static (PixelLocation[] points, double nextSetback) GetSubPoints(PixelLocation pt1, PixelLocation pt2, double spacing, double setback)
    {
        double dx = pt2.X - pt1.X;
        double dy = pt2.Y - pt1.Y;
        double distanceBetweenPoints = Math.Sqrt(dx * dx + dy * dy);
        double angle = Math.Atan(dy / dx);
        if (dx < 0)
            angle += Math.PI;

        List<PixelLocation> points = new();
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

    // TODO: file IO
}
