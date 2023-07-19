namespace DendriteTracer.Gui
{
    public partial class RoiConfigurator : UserControl
    {
        public event EventHandler RoiSettingsChanged = delegate { };

        public double ThresholdFloor => cbEnableThreshold.Checked ? (double)nudPixelThresholdFloor.Value : 0;
        public double ThresholdMult => cbEnableThreshold.Checked ? (double)nudPixelThresholdMult.Value : 0;

        public RoiConfigurator()
        {
            InitializeComponent();

            nudPixelThresholdFloor.ValueChanged += (s, e) => OnSettingsChanged();
            nudPixelThresholdMult.ValueChanged += (s, e) => OnSettingsChanged();
            cbEnableThreshold.CheckedChanged += (s, e) => OnSettingsChanged();
        }

        private void OnSettingsChanged()
        {
            RoiSettingsChanged.Invoke(this, EventArgs.Empty);
        }
    }
}
