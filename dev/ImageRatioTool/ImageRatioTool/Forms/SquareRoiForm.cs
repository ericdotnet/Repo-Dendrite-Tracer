namespace ImageRatioTool.Forms;

public partial class SquareRoiForm : Form
{
    private string ResultsToCopy = string.Empty;

    public SquareRoiForm()
    {
        InitializeComponent();
        tSeriesRoiSelector1.AnalysisUpdated += TSeriesRoiSelector1_AnalysisUpdated;
        tSeriesRoiSelector1.LoadFile(SampleData.RatiometricImageSeries);
    }

    private void btnSelectImage_Click(object sender, EventArgs e)
    {
        OpenFileDialog diag = new()
        {
            Filter = "TIF files (*.tif)|*.tif",
            Title = "Select a 2-channel TSeries TIF file",
        };

        if (diag.ShowDialog() == DialogResult.OK)
            tSeriesRoiSelector1.LoadFile(diag.FileName);
    }

    private void TSeriesRoiSelector1_AnalysisUpdated(object? sender, RoiAnalysis e)
    {
        GraphOperations.PlotIntensities(formsPlot1, e);
        GraphOperations.PlotRatios(formsPlot2, e);
    }

    private void btnAnalyzeAllFrames_Click(object sender, EventArgs e)
    {
        double[] values = new double[tSeriesRoiSelector1.FrameCount];

        for (int i = 0; i < tSeriesRoiSelector1.FrameCount; i++)
        {
            RoiAnalysis analysis = tSeriesRoiSelector1.Analyze(i);
            values[i] = analysis.MedianRatio * 100;
        }

        formsPlot3.Plot.Clear();
        formsPlot3.Plot.AddSignal(values);
        formsPlot3.Plot.YLabel("G/R (%)");
        formsPlot3.Plot.XLabel("Frame Number");
        formsPlot3.Refresh();

        ResultsToCopy = string.Join("\n", values.Select(x => x.ToString()));
    }

    private void btnCopyResults_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ResultsToCopy))
            return;

        Clipboard.SetText(ResultsToCopy);
    }

    private void btnCopyImage_Click(object sender, EventArgs e)
    {
        Clipboard.SetImage(tSeriesRoiSelector1.GetImage());
    }

    private void tbThreshold_Scroll(object sender, EventArgs e)
    {
        double threshold = tbThreshold.Value / 10.0;
        lblThreshold.Text = $"Threshold: {threshold:#.#}";
        tSeriesRoiSelector1.Threshold = threshold;
        tSeriesRoiSelector1.Analyze();
    }
}