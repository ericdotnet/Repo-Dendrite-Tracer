namespace DendriteTracer.Gui
{
    public partial class RoiConfigurator : UserControl
    {
        public event EventHandler RoiSettingsChanged = delegate { };

        public double ThresholdFloor => (double)nudPixelThresholdFloor.Value;
        public double ThresholdMult => (double)nudPixelThresholdMult.Value;

        public RoiConfigurator()
        {
            InitializeComponent();

            nudPixelThresholdFloor.ValueChanged += (s, e) => OnSettingsChanged();
            nudPixelThresholdMult.ValueChanged += (s, e) => OnSettingsChanged();
        }

        private void OnSettingsChanged()
        {
            RoiSettingsChanged.Invoke(this, EventArgs.Empty);
        }
    }
}
