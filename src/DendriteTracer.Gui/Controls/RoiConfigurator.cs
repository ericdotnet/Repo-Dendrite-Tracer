using DendriteTracer.Core;

namespace DendriteTracer.Gui
{
    public partial class RoiConfigurator : UserControl
    {
        public event EventHandler<Analysis> AnalysisChanged = delegate { };

        private Analysis? LastAnalysis;

        public RoiConfigurator()
        {
            InitializeComponent();

            nudImageSubtractionFloor.ValueChanged += (s, e) => OnSettingsChanged();
            cbImageSubtractionEnabled.CheckedChanged += (s, e) => OnSettingsChanged();
            nudPixelThresholdFloor.ValueChanged += (s, e) => OnSettingsChanged();
            nudPixelThresholdMult.ValueChanged += (s, e) => OnSettingsChanged();
        }

        public void LoadTif(string path, PixelLocation[]? initialPoints = null)
        {
            AnalysisSettings settings = new(path);
            LastAnalysis = new Analysis(settings);

            if (initialPoints is not null)
                LastAnalysis.Tracing.AddRange(initialPoints);

            OnSettingsChanged();
        }

        private void OnSettingsChanged()
        {

        }
    }
}
