namespace ImageRatioTool;

/// <summary>
/// Represents part of an ROI which can be grabbed and manipulated
/// </summary>
public enum RoiGrab
{
    None,
    TopLeft,
    TopCenter,
    TopRight,
    RightCenter,
    BottomRight,
    BottomCenter,
    BottomLeft,
    LeftCenter,
    Center,
}

public static class RoiGrabExtensions
{
    public static Cursor GetCursor(this RoiGrab grab)
    {
        return grab switch
        {
            RoiGrab.None => Cursors.Arrow,
            RoiGrab.TopLeft => Cursors.SizeNWSE,
            RoiGrab.TopCenter => Cursors.SizeNS,
            RoiGrab.TopRight => Cursors.SizeNESW,
            RoiGrab.RightCenter => Cursors.SizeWE,
            RoiGrab.BottomRight => Cursors.SizeNWSE,
            RoiGrab.BottomCenter => Cursors.SizeNS,
            RoiGrab.BottomLeft => Cursors.SizeNESW,
            RoiGrab.LeftCenter => Cursors.SizeWE,
            RoiGrab.Center => Cursors.SizeAll,
            _ => throw new NotImplementedException(),
        };
    }

    public static bool IsLeftSide(this RoiGrab grab)
    {
        return grab == RoiGrab.TopLeft || grab == RoiGrab.LeftCenter || grab == RoiGrab.BottomLeft;
    }

    public static bool IsTopSide(this RoiGrab grab)
    {
        return grab == RoiGrab.TopLeft || grab == RoiGrab.TopCenter || grab == RoiGrab.TopRight;
    }

    public static bool IsRightSide(this RoiGrab grab)
    {
        return grab == RoiGrab.TopRight || grab == RoiGrab.RightCenter || grab == RoiGrab.BottomRight;
    }

    public static bool IsBottomSide(this RoiGrab grab)
    {
        return grab == RoiGrab.BottomLeft || grab == RoiGrab.BottomCenter || grab == RoiGrab.BottomRight;
    }
}