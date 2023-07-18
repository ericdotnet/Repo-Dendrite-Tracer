using DendriteTracer.Core;
using System.IO;

namespace DendriteTracer.Gui
{
    public partial class UserInputs : UserControl
    {
        public event EventHandler<Analysis> AnalysisChanged = delegate { };

        private Analysis? LastAnalysis;

        public UserInputs()
        {
            InitializeComponent();
            AllowDrop = true;

            btnLoadImage.Click += (s, e) =>
            {
                OpenFileDialog diag = new() { Filter = "TIF files (*.tif, *.tiff)|*.tif;*.tiff" };
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    LoadTif(diag.FileName);
                }
            };

            DragEnter += (s, e) =>
            {
                if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy;
            };

            DragDrop += (s, e) =>
            {
                string[] paths = (string[])e.Data!.GetData(DataFormats.FileDrop)!;
                LoadTif(paths.First());
            };

            nudImageSubtractionFloor.ValueChanged += (s, e) => OnSettingsChanged(true);
            cbImageSubtractionEnabled.CheckedChanged += (s, e) => OnSettingsChanged(true);
            nudRoiRadius.ValueChanged += (s, e) => OnSettingsChanged();
            nudRoiSpacing.ValueChanged += (s, e) => OnSettingsChanged();
            cbRoiCirular.CheckedChanged += (s, e) => OnSettingsChanged();
            nudPixelThresholdFloor.ValueChanged += (s, e) => OnSettingsChanged();
            nudPixelThresholdMult.ValueChanged += (s, e) => OnSettingsChanged();
            nudBrightness.ValueChanged += (s, e) => OnSettingsChanged();
        }

        public void LoadTif(string path, PixelLocation[]? initialPoints = null)
        {
            AnalysisSettings settings = new(path);
            LastAnalysis = new Analysis(settings);

            if (initialPoints is not null)
                LastAnalysis.Tracing.AddRange(initialPoints);

            OnSettingsChanged();
        }

        private void OnSettingsChanged(bool reload = false)
        {
            if (LastAnalysis is null)
                return;

            if (reload)
            {
                var oldTrace = LastAnalysis.Tracing.GetPixels();
                AnalysisSettings settings = new(LastAnalysis.Settings.TifFilePath);
                LastAnalysis = new Analysis(settings);
                LastAnalysis.Tracing.AddRange(oldTrace);
            }

            LastAnalysis.Settings.ImageSubtractionFloor_Percent = cbImageSubtractionEnabled.Checked ? (double)nudImageSubtractionFloor.Value : 0;
            LastAnalysis.Settings.RoiSpacing_Microns = (double)nudRoiSpacing.Value;
            LastAnalysis.Settings.RoiRadius_Microns = (double)nudRoiRadius.Value;
            LastAnalysis.Settings.RoiIsCircular = cbRoiCirular.Checked;
            LastAnalysis.Settings.PixelThresholdFloor_Percent = (double)nudPixelThresholdFloor.Value;
            LastAnalysis.Settings.PixelThreshold_Multiple = (double)nudPixelThresholdMult.Value;
            LastAnalysis.Settings.Brightness = (double)nudBrightness.Value;

            AnalysisChanged.Invoke(this, LastAnalysis);
        }
    }
}
