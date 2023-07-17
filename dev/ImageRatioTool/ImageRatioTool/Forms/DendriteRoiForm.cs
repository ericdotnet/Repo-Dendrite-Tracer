namespace ImageRatioTool.Forms;

public partial class DendriteRoiForm : Form
{

    public DendriteRoiForm()
    {
        InitializeComponent();

        dendriteTracerControl1.SetData(SampleData.RatiometricImageSeries);
    }
}
