namespace ImageRatioTool;

/// <summary>
/// Holds mutable boundaries of a rectangular region of interest.
/// Units are pixels. X ascends from left to right. Y ascends from top to bottom.
/// </summary>
public class RoiRectangle
{
    public int XMin { get; private set; }
    public int XMax { get; private set; }
    public int YMin { get; private set; }
    public int YMax { get; private set; }
    public int XCenter => (XMin + XMax) / 2;
    public int YCenter => (YMin + YMax) / 2;
    public int Width => XMax - XMin;
    public int Height => YMax - YMin;
    public Point TopLeft => new(XMin, YMin);
    public Point TopRight => new(XMax, YMin);
    public Point BottomLeft => new(XMin, YMax);
    public Point BottomRight => new(XMax, YMax);
    public Point TopCenter => new(XCenter, YMin);
    public Point BottomCenter => new(XCenter, YMax);
    public Point LeftCenter => new(XMin, YCenter);
    public Point RightCenter => new(XMax, YCenter);
    public Point[] Corners => new Point[] { TopLeft, TopRight, BottomRight, BottomLeft };
    public Point[] Centers => new Point[] { LeftCenter, TopCenter, RightCenter, BottomCenter };
    public Rectangle Rect => new(XMin, YMin, Width, Height);

    public void Update(int x1, int y1, int x2, int y2)
    {
        // TODO: limit to size of image
        UpdateX(x1, x2);
        UpdateY(y1, y2);
    }

    private void UpdateX(int x1, int x2)
    {
        if (x1 == x2)
            x2 += 1;

        XMin = Math.Min(x1, x2);
        XMax = Math.Max(x1, x2);
    }

    private void UpdateY(int y1, int y2)
    {
        if (y1 == y2)
            y2 += 1;

        YMin = Math.Min(y1, y2);
        YMax = Math.Max(y1, y2);
    }

    public void Update(RoiGrab grab, Point mouse, Rectangle initialRect, Point initialPoint)
    {
        if (grab == RoiGrab.None)
            return;

        if (grab == RoiGrab.Center)
        {
            int dX = mouse.X - initialPoint.X;
            int dY = mouse.Y - initialPoint.Y;
            UpdateX(initialRect.Left + dX, initialRect.Right + dX);
            UpdateY(initialRect.Top + dY, initialRect.Bottom + dY);
            return;
        }

        if (grab.IsLeftSide())
            UpdateX(mouse.X, initialRect.Right);

        if (grab.IsRightSide())
            UpdateX(mouse.X, initialRect.Left);

        if (grab.IsTopSide())
            UpdateY(mouse.Y, initialRect.Bottom);

        if (grab.IsBottomSide())
            UpdateY(mouse.Y, initialRect.Top);
    }

    public RoiGrab GetGrabUnderCursor(Point cursorLocation)
    {
        double snapDistance = 5;

        if (cursorLocation.DistanceFrom(TopLeft) < snapDistance)
            return RoiGrab.TopLeft;

        if (cursorLocation.DistanceFrom(TopCenter) < snapDistance)
            return RoiGrab.TopCenter;

        if (cursorLocation.DistanceFrom(TopRight) < snapDistance)
            return RoiGrab.TopRight;

        if (cursorLocation.DistanceFrom(RightCenter) < snapDistance)
            return RoiGrab.RightCenter;

        if (cursorLocation.DistanceFrom(BottomRight) < snapDistance)
            return RoiGrab.BottomRight;

        if (cursorLocation.DistanceFrom(BottomCenter) < snapDistance)
            return RoiGrab.BottomCenter;

        if (cursorLocation.DistanceFrom(BottomLeft) < snapDistance)
            return RoiGrab.BottomLeft;

        if (cursorLocation.DistanceFrom(LeftCenter) < snapDistance)
            return RoiGrab.BottomLeft;

        bool cursorInsideX = cursorLocation.X >= XMin && cursorLocation.X <= XMax;
        bool cursorInsideY = cursorLocation.Y >= YMin && cursorLocation.Y <= YMax;
        if (cursorInsideX && cursorInsideY)
            return RoiGrab.Center;

        return RoiGrab.None;
    }
}
