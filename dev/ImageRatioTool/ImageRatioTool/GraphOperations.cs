using ScottPlot;

namespace ImageRatioTool;

internal static class GraphOperations
{
    public static void PlotIntensities(FormsPlot fp, RoiAnalysis roi)
    {
        fp.Plot.Clear();

        fp.Plot.AddSignal(roi.SortedValues);

        var floorLine = fp.Plot.AddHorizontalLine(roi.NoiseFloor, Color.Blue, 1, ScottPlot.LineStyle.Dot);
        floorLine.PositionLabel = true;
        floorLine.PositionLabelOppositeAxis = true;
        floorLine.PositionFormatter = (double x) => $"{x:N0}";
        floorLine.PositionLabelBackground = floorLine.Color;

        var thresholdLine = fp.Plot.AddHorizontalLine(roi.Threshold, Color.Green, 1, ScottPlot.LineStyle.Dash);
        thresholdLine.PositionLabel = true;
        thresholdLine.PositionLabelOppositeAxis = true;
        thresholdLine.PositionFormatter = (double x) => $"{x:N0}";
        thresholdLine.PositionLabelBackground = thresholdLine.Color;

        fp.Plot.YLabel("Intensity (AFU)");
        fp.Plot.Legend(true, Alignment.UpperLeft);
        fp.Plot.Layout(right: 50);
        fp.Refresh();
    }

    public static void PlotRatios(FormsPlot fp, RoiAnalysis roi)
    {
        if (roi.SortedRatios.Length == 0)
        {
            fp.Plot.Clear();
            fp.Refresh();
            return;
        }

        fp.Visible = true;
        fp.Plot.Clear();

        //PlotRatioDistributionAndMedian(fp.Plot, roi);
        PlotRatioHistogram(fp.Plot, roi);

        fp.Refresh();
    }

    private static void PlotRatioDistributionAndMedian(Plot plt, RoiAnalysis roi)
    {
        plt.AddSignal(roi.SortedRatios);

        plt.AddVerticalLine(roi.MedianIndex, Color.Black, 1, LineStyle.Dot);
        var hline = plt.AddHorizontalLine(roi.MedianRatio, Color.Black, 1, LineStyle.Dash);
        hline.PositionLabel = true;
        hline.PositionLabelOppositeAxis = true;
        hline.PositionFormatter = (double x) => $"{x * 100:N2}%";

        plt.YLabel("G/R Ratio");
        plt.Layout(right: 50);
    }

    private static void PlotRatioHistogram(Plot plt, RoiAnalysis roi)
    {
        ScottPlot.Statistics.Histogram hist = new(min: 0, max: 500, binCount: 500);

        foreach (double ratio in roi.SortedRatios)
        {
            hist.Add(ratio * 100);
        }

        var bar = plt.AddBar(hist.Counts, hist.BinCenters);
        bar.BorderLineWidth = 0;
        bar.BarWidth = hist.BinSize * 1.2;


        double median = roi.MedianRatio * 100;
        plt.AddVerticalLine(median, Color.Black, 2, LineStyle.Dash);

        plt.YLabel("Count");
        plt.XLabel("G/R (%)");
        plt.Title($"Median: {median:##.###}% (n={roi.PixelsAboveThreshold:N0})");

        plt.SetAxisLimits(
            xMin: roi.SortedRatios.First() * 100 - 10,
            xMax: roi.SortedRatios.Last() * 100 + 10,
            yMin: 0);
    }
}
