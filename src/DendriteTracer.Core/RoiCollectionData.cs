using BitMiracle.LibTiff.Classic;
using RasterSharp;

namespace DendriteTracer.Core;

public class RoiCollectionData
{
    public Channel[] Reds { get; }
    public Channel[] Greens { get; }
    public Image[] Images { get; }
    public double[][] RedValuesSorted { get; }
    public int Length => Images.Length;

    public RoiCollectionData(ImageWithTracing iwt)
    {
        (Reds, Greens) = iwt.GetRoiChannels();

        Images = GetPreviewImages();

        RedValuesSorted = Reds.Select(x => x.GetValues().OrderBy(x => x).ToArray()).ToArray();
    }

    private Image[] GetPreviewImages()
    {
        Image[] images = new Image[Reds.Length];

        for (int i = 0; i < Reds.Length; i++)
        {
            Channel r = Reds[i].Clone();
            Channel g = Greens[i].Clone();

            r.Rescale();
            g.Rescale();

            images[i] = new Image(r, g, r);
        }


        return images;
    }

    public Image GetThresholdImage(double threshold, int roiIndex)
    {
        RasterSharp.Image img = new(Reds[0].Width, Reds[0].Height);

        for (int y = 0; y < img.Height; y++)
        {
            for (int x = 0; x < img.Width; x++)
            {
                if (Reds[roiIndex].GetValue(x, y) < threshold)
                {
                    img.Red.SetValue(x, y, 0);
                    img.Green.SetValue(x, y, 0);
                    img.Blue.SetValue(x, y, 255);
                }
                else
                {
                    img.Red.SetValue(x, y, 255);
                    img.Green.SetValue(x, y, 0);
                    img.Blue.SetValue(x, y, 0);
                }
            }
        }

        return img;
    }

    public (double[] reds, double[] greens, PixelLocation[] locations) GetPixelsAboveThreshold(double threshold, int roiIndex)
    {
        List<double> reds = new();
        List<double> greens = new();
        List<PixelLocation> locations = new();


        for (int y = 0; y < Reds[0].Height; y++)
        {
            for (int x = 0; x < Reds[0].Width; x++)
            {
                if (Reds[roiIndex].GetValue(x, y) >= threshold)
                {
                    reds.Add(Reds[roiIndex].GetValue(x, y));
                    greens.Add(Greens[roiIndex].GetValue(x, y));
                    locations.Add(new PixelLocation(x, y));
                }
            }
        }

        return (reds.ToArray(), greens.ToArray(), locations.ToArray());
    }

    public (double[] reds, double[] greens, double[] ratios) GetCurves(double redThreshold)
    {
        double[] redMeans = new double[Length];
        double[] greenMeans = new double[Length];
        double[] ratioMeans = new double[Length];

        for (int i = 0; i < Length; i++)
        {
            (double[] reds, double[] greens, PixelLocation[] locations) = GetPixelsAboveThreshold(redThreshold, i);
            double[] ratios = Enumerable.Range(0, reds.Length).Select(x => greens[x] / reds[x] * 100).ToArray();

            redMeans[i] = Mean(reds);
            greenMeans[i] = Mean(greens);
            ratioMeans[i] = Mean(ratios);
        }

        return (redMeans, greenMeans, ratioMeans);
    }

    private static double Mean(double[] values)
    {
        return values.Any() ? values.Sum() / values.Length : 0;
    }
}
