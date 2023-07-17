using DendriteTracer.Core;

namespace DendriteTracer.Gui;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        string startupImage = Path.GetFullPath("../../../../DendriteTracer.Tests/SampleData/MAX_TSeries-04132023-1214-2165.tif");

        if (File.Exists(startupImage))
        {
            PixelLocation[] points =
            {
                new(150, 370),
                new(192, 337),
                new(216, 306),
                new(227, 273),
                new(245, 260),
                new(262, 243),
                new(262, 225),
                new(253, 207),
                new(259, 197),
                new(278, 173),
                new(295, 143),
                new(316, 124),
                new(371, 105),
                new(402, 79),
                new(402, 52),
                new(400, 23),
            };

            imageTracer1.LoadImge(startupImage, points);
        }
        else
        {
            System.Diagnostics.Debug.WriteLine($"STARTUP IMAGE NOT FOUND: {startupImage}");
        }
    }
}
