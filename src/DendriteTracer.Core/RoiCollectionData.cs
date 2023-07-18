using BitMiracle.LibTiff.Classic;
using RasterSharp;

namespace DendriteTracer.Core;

public class RoiCollectionData
{
    public Channel[] Reds { get; }
    public Channel[] Greens { get; }
    public double[][] RedValuesSorted { get; }
    public int RoiCount => Reds.Length;

    public RoiCollectionData(ImageWithTracing iwt)
    {
        (Reds, Greens) = iwt.GetRoiChannels();

        RedValuesSorted = Reds.Select(x => x.GetValues().OrderBy(x => x).ToArray()).ToArray();
    }

    public Image GetMergedImage(int roiIndex)
    {
        Channel r = Reds[roiIndex].Clone();
        Channel g = Greens[roiIndex].Clone();

        r.Rescale();
        g.Rescale();

        return new Image(r, g, r);
    }

    public (double floor, double threshold) GetThreshold(double percent, double multiple, int roiIndex)
    {
        double[] sorted = Reds[roiIndex].GetValues().OrderBy(x => x).ToArray();
        int floorIndex = (int)(percent * sorted.Length / 100.0);
        double floor = sorted[floorIndex];
        double threshold = floor * multiple;
        return (floor, threshold);
    }

    public Image GetThresholdImage(double threshold, int roiIndex, bool circular)
    {
        RasterSharp.Image img = new(Reds[0].Width, Reds[0].Height);

        for (int y = 0; y < img.Height; y++)
        {
            for (int x = 0; x < img.Width; x++)
            {
                bool isAboveThreshold = Reds[roiIndex].GetValue(x, y) >= threshold;

                if (isAboveThreshold && circular)
                {
                    double radius = (double)Reds[0].Width / 2;
                    double dX = Math.Abs(radius - x);
                    double dY = Math.Abs(radius - y);
                    double distanceFromCenter = Math.Sqrt(dX * dX + dY * dY);
                    if (distanceFromCenter > radius)
                        isAboveThreshold = false;
                }

                if (isAboveThreshold)
                {
                    img.Red.SetValue(x, y, 255);
                    img.Green.SetValue(x, y, 0);
                    img.Blue.SetValue(x, y, 0);
                }
                else
                {
                    img.Red.SetValue(x, y, 0);
                    img.Green.SetValue(x, y, 0);
                    img.Blue.SetValue(x, y, 255);
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
        double[] redMeans = new double[RoiCount];
        double[] greenMeans = new double[RoiCount];
        double[] ratioMeans = new double[RoiCount];

        for (int i = 0; i < RoiCount; i++)
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
