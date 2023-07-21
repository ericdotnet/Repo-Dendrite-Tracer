using DendriteTracer.Core;
using ScottPlot;

namespace DendriteTracer.Gui;

public partial class ResultsViewer : UserControl
{
    int SelectedFrame = 0;
    int SelectedRoi = 0;
    RoiCollection? RoiCollection;

    public ResultsViewer()
    {
        InitializeComponent();
        cbOverTime.Enabled = false;

        cbAllFrames.CheckedChanged += (s, e) =>
        {
            cbOverTime.Enabled = cbAllFrames.Checked;
            UpdatePlots();
        };

        cbOverTime.CheckedChanged += (s, e) => UpdatePlots();

        btnSave.Click += (s, e) =>
        {
            if (RoiCollection is null)
                return;

            SaveFileDialog savefile = new()
            {
                FileName = Path.GetFileNameWithoutExtension(RoiCollection.TifFilePath) + ".json",
                Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*",

            };

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                RoiCollection.SaveJson(savefile.FileName);
            }
        };
    }

    public void SetSelectedFrameAndRoi(int frame, int roi)
    {
        SelectedFrame = frame;
        SelectedRoi = roi;
        UpdatePlots();
    }

    public void LoadRois(RoiCollection roiCollection)
    {
        Visible = roiCollection.RoiCount > 0;
        if (roiCollection.RoiCount == 0)
            return;

        RoiCollection = roiCollection;
        UpdatePlots();
    }

    public void UpdatePlots()
    {
        if (RoiCollection is null)
            return;

        try
        {
            if (cbAllFrames.Checked)
            {
                if (cbOverTime.Checked)
                {
                    PlotAllFramesOverTime(RoiCollection);
                }
                else
                {
                    PlotAllFramesOverlapping(RoiCollection);
                }
            }
            else
            {
                PlotSingleFrame(RoiCollection);
            }
        }
        catch (Exception ex)
        {
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.Title(ex.ToString());
            formsPlot1.Refresh();

            formsPlot2.Plot.Clear();
            formsPlot2.Refresh();
        }
    }

    private void PlotSingleFrame(RoiCollection c)
    {
        formsPlot1.Plot.Clear();
        formsPlot1.Plot.Title($"PMT Readings (Frame {SelectedFrame + 1})");
        formsPlot1.Plot.XLabel("Distance (µm)");
        formsPlot1.Plot.YLabel("Fluorescence (AFU)");
        formsPlot1.Plot.AddScatter(c.Positions, c.RedCurveByFrame[SelectedFrame], Color.Red, label: "Red PMT");
        formsPlot1.Plot.AddScatter(c.Positions, c.GreenCurveByFrame[SelectedFrame], Color.Green, label: "Green PMT");
        formsPlot1.Plot.Legend(true, Alignment.UpperRight);
        MarkRoi(c, formsPlot1.Plot);
        AutoLimitsPMT(c, formsPlot1.Plot);
        formsPlot1.Refresh();

        formsPlot2.Plot.Clear();
        formsPlot2.Plot.Title($"G/R Ratios (Frame {SelectedFrame + 1})");
        formsPlot2.Plot.XLabel("Distance (µm)");
        formsPlot2.Plot.YLabel("Green/Red (%)");
        formsPlot2.Plot.AddScatter(c.Positions, c.RatioCurveByFrame[SelectedFrame], Color.Blue);
        MarkRoi(c, formsPlot2.Plot);
        AutoLimitsRatio(c, formsPlot2.Plot);
        formsPlot2.Refresh();
    }

    private void PlotAllFramesOverlapping(RoiCollection c)
    {
        formsPlot1.Plot.Clear();
        formsPlot1.Plot.Title($"Fluorescence (All Frames)");
        formsPlot1.Plot.XLabel("Distance (µm)");
        formsPlot1.Plot.YLabel("PMT Reading (AFU)");
        for (int i = 0; i < c.FrameCount; i++)
        {
            formsPlot1.Plot.AddScatterLines(c.Positions, c.RedCurveByFrame[i],
                color: i == SelectedFrame ? Color.Red : Color.FromArgb(50, Color.Red),
                lineWidth: i == SelectedFrame ? 3 : 1);

            formsPlot1.Plot.AddScatterLines(c.Positions, c.GreenCurveByFrame[i],
                color: i == SelectedFrame ? Color.Green : Color.FromArgb(50, Color.Green),
                lineWidth: i == SelectedFrame ? 3 : 1);
        }
        MarkRoi(c, formsPlot1.Plot);
        AutoLimitsPMT(c, formsPlot1.Plot);
        formsPlot1.Refresh();

        formsPlot2.Plot.Clear();
        formsPlot2.Plot.Title($"G/R Ratios (All Frames)");
        formsPlot2.Plot.XLabel("Distance (µm)");
        formsPlot2.Plot.YLabel("Green/Red (%)");
        for (int i = 0; i < c.FrameCount; i++)
        {
            formsPlot2.Plot.AddScatterLines(c.Positions, c.RatioCurveByFrame[i],
                color: i == SelectedFrame ? Color.Blue : Color.FromArgb(50, Color.Blue),
                lineWidth: i == SelectedFrame ? 3 : 1);
        }
        MarkRoi(c, formsPlot2.Plot);
        AutoLimitsRatio(c, formsPlot2.Plot);
        formsPlot2.Refresh();
    }

    private void PlotAllFramesOverTime(RoiCollection c)
    {
        formsPlot1.Plot.Clear();
        formsPlot1.Plot.Title($"Fluorescence (All Frames over time)");
        formsPlot1.Plot.XLabel("Distance and time (AU)");
        formsPlot1.Plot.YLabel("PMT Reading (AFU)");

        for (int i = 0; i < c.FrameCount; i++)
        {
            double[] xs = c.Positions.Select(x => i + (x / c.Positions.Last()) * .8).ToArray();

            formsPlot1.Plot.AddScatterLines(xs, c.RedCurveByFrame[i],
                color: i == SelectedFrame ? Color.Red : Color.FromArgb(50, Color.Red),
                lineWidth: i == SelectedFrame ? 3 : 1);

            formsPlot1.Plot.AddScatterLines(xs, c.GreenCurveByFrame[i],
                color: i == SelectedFrame ? Color.Green : Color.FromArgb(50, Color.Green),
                lineWidth: i == SelectedFrame ? 3 : 1);
        }

        AutoLimitsPMT(c, formsPlot1.Plot);
        formsPlot1.Refresh();

        formsPlot2.Plot.Clear();
        formsPlot2.Plot.Title($"G/R Ratios (All Frames)");
        formsPlot2.Plot.XLabel("Distance (µm)");
        formsPlot2.Plot.YLabel("Green/Red (%)");
        for (int i = 0; i < c.FrameCount; i++)
        {
            double[] xs = c.Positions.Select(x => i + (x / c.Positions.Last()) * .8).ToArray();

            formsPlot2.Plot.AddScatterLines(xs, c.RatioCurveByFrame[i],
                color: i == SelectedFrame ? Color.Blue : Color.FromArgb(50, Color.Blue),
                lineWidth: i == SelectedFrame ? 3 : 1);
        }
        AutoLimitsRatio(c, formsPlot2.Plot);
        formsPlot2.Refresh();
    }

    private void MarkRoi(RoiCollection c, Plot plt)
    {
        plt.AddVerticalLine(c.Positions[SelectedRoi], Color.Black, 1, LineStyle.Dash); ;
    }

    private static void AutoLimitsPMT(RoiCollection c, Plot plt)
    {
        double min = Math.Min(
            c.RedCurveByFrame.Select(x => x.Min()).Min(),
            c.GreenCurveByFrame.Select(x => x.Min()).Min());

        double max = Math.Max(
            c.RedCurveByFrame.Select(x => x.Max()).Max(),
            c.GreenCurveByFrame.Select(x => x.Max()).Max());

        plt.SetAxisLimitsY(Math.Min(min, 0), max);
    }

    private static void AutoLimitsRatio(RoiCollection c, Plot plt)
    {
        double min = c.RatioCurveByFrame.Select(x => x.Min()).Min();
        double max = c.RatioCurveByFrame.Select(x => x.Max()).Max();

        plt.SetAxisLimitsY(Math.Min(min, 0), max);
    }
}