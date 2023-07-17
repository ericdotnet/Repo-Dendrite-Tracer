namespace DendriteTracer.Gui;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        string startupImage = Path.GetFullPath("../../../../DendriteTracer.Tests/SampleData/MAX_TSeries-04132023-1214-2165.tif");

        if (File.Exists(startupImage))
        {
            imageTracer1.LoadImge(startupImage);
        }
        else
        {
            System.Diagnostics.Debug.WriteLine($"STARTUP IMAGE NOT FOUND: {startupImage}");
        }
    }
}
