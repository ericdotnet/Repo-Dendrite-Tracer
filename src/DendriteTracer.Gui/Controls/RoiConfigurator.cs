namespace DendriteTracer.Gui
{
    public partial class RoiConfigurator : UserControl
    {
        public event EventHandler RoiSettingsChanged = delegate { };

        public double SubtractionFloor => (double)nudImageSubtractionFloor.Value;
        public double ThresholdFloor => (double)nudPixelThresholdFloor.Value;
        public double ThresholdMult => (double)nudPixelThresholdMult.Value;

        public RoiConfigurator()
        {
            InitializeComponent();

            nudImageSubtractionFloor.ValueChanged += (s, e) => OnSettingsChanged();
            cbImageSubtractionEnabled.CheckedChanged += (s, e) => OnSettingsChanged();
            nudPixelThresholdFloor.ValueChanged += (s, e) => OnSettingsChanged();
            nudPixelThresholdMult.ValueChanged += (s, e) => OnSettingsChanged();
        }

        private void OnSettingsChanged()
        {
            RoiSettingsChanged.Invoke(this, EventArgs.Empty);
        }
    }
}
