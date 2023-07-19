﻿namespace DendriteTracer.Core;

/// <summary>
/// This class contains stateless functions for performing common operations
/// </summary>
internal static class ArrayOperations
{
    public static double[][] GetCurveByFrame(double[,] values)
    {
        int frameCount = values.GetLength(0);
        int roiCount = values.GetLength(1);

        double[][] curves = new double[frameCount][];

        for (int i = 0; i < frameCount; i++)
        {
            double[] curve = new double[roiCount];

            for (int j = 0; j < roiCount; j++)
            {
                curve[j] = values[i, j];
            }

            curves[i] = curve;
        }

        return curves;
    }

    public static double[,] GetRatios(double[,] reds, double[,] greens)
    {
        int frameCount = reds.GetLength(0);
        int roiCount = reds.GetLength(1);

        double[,] ratios = new double[frameCount, roiCount];

        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < roiCount; j++)
            {
                ratios[i, j] = 100 * greens[i, j] / reds[i, j];
            }
        }

        return ratios;
    }

    public static double[,] GetMeans(RasterSharp.Channel[,] images, bool[,][,] masks)
    {
        int frameCount = images.GetLength(0);
        int roiCount = images.GetLength(1);

        double[,] means = new double[frameCount, roiCount];

        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < roiCount; j++)
            {
                means[i, j] = GetMean(images[i, j], masks[i, j]);
            }
        }

        return means;
    }

    public static double[,] GetMeans(RasterSharp.Channel[,] images)
    {
        int frameCount = images.GetLength(0);
        int roiCount = images.GetLength(1);

        double[,] means = new double[frameCount, roiCount];

        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < roiCount; j++)
            {
                means[i, j] = GetMean(images[i, j]);
            }
        }

        return means;
    }

    public static double GetMean(RasterSharp.Channel image, bool[,] mask)
    {
        List<double> values = new();

        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                if (mask[y, x])
                {
                    values.Add(image.GetValue(y, x));
                }
            }
        }

        // TODO: better way to handle no data?
        return values.Any() ? values.Sum() / values.Count : -100;
    }

    public static double GetMean(RasterSharp.Channel image)
    {
        List<double> values = new();

        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                values.Add(image.GetValue(y, x));
            }
        }

        return values.Sum() / values.Count;
    }

    public static double[] GetThresholdsByFrame(double[][] sortedByFrame, double[] floors, double mult)
    {
        int frameCount = floors.Length;

        double[] thresholds = new double[frameCount];

        for (int i = 0; i < frameCount; i++)
        {
            double lowest = sortedByFrame[0][0];
            double floorDistFromLowest = floors[i] - lowest;
            double thresholdDistFromLowest = floorDistFromLowest * mult;
            thresholds[i] = lowest + thresholdDistFromLowest;
        }

        return thresholds;
    }

    public static double[] GetNoiseFloorsByFrame(double[][] SortedRedPixels, double percentile)
    {
        int frameCount = SortedRedPixels.Length;

        double[] floors = new double[frameCount];

        for (int i = 0; i < frameCount; i++)
        {
            int index = (int)(SortedRedPixels[i].Length * percentile / 100.0);
            floors[i] = SortedRedPixels[i][index];
        }

        return floors;
    }

    public static double[,][] GetSortedPixels(RasterSharp.Channel[,] imgs)
    {
        int frameCount = imgs.GetLength(0);
        int roiCount = imgs.GetLength(1);
        int pixelsPerRoi = frameCount * roiCount;

        double[,][] pixels = new double[frameCount, roiCount][];

        for (int i = 0; i < frameCount; i++)
        {
            for (int j = 0; j < roiCount; j++)
            {
                pixels[i, j] = imgs[i, j].GetValues().OrderBy(x => x).ToArray();
            }
        }

        return pixels;
    }

    public static double[][] GetSortedPixels(RasterSharp.Channel[] imgs)
    {
        int frameCount = imgs.Length;

        double[][] pixels = new double[frameCount][];

        for (int i = 0; i < frameCount; i++)
        {
            pixels[i] = imgs[i].GetValues().OrderBy(x => x).ToArray();
        }

        return pixels;
    }
}
