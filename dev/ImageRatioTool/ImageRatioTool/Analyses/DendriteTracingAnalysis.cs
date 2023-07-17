using ScottPlot.Drawing.Colormaps;
using System.Windows.Forms;

namespace ImageRatioTool.Analyses;

internal class DendriteTracingAnalysis
{
    /// <summary>
    /// Where the user clicked to trace the dendrite
    /// </summary>
    private readonly List<FractionalPoint> MousePoints = new();

    public DendriteTracingAnalysis()
    {

    }

    public void AddMousePoint(double fracX, double fracY)
    {
        MousePoints.Add(new(fracX, fracY));
    }

    public void AddMousePoint(int x, int y, int width, int height)
    {
        double fracX = (double)x / width;
        double fracY = (double)y / height;
        AddMousePoint(fracX, fracY);
    }

    public void ClearMousePoints()
    {
        MousePoints.Clear();
    }

    public Point[] GetMousePoints(int width, int height)
    {
        return MousePoints.Select(x => x.ToPoint(width, height)).ToArray();
    }

    public FractionalPoint[] GetMousePoints()
    {
        return MousePoints.ToArray();
    }
}
