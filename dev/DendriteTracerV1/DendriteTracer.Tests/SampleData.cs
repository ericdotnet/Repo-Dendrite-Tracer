using DendriteTracer.Core;

namespace DendriteTracer.Tests;

internal class SampleData
{
    public static string TSERIES_2CH_PATH = Path.GetFullPath(
        Path.Combine(
            TestContext.CurrentContext.TestDirectory,
            "../../../../../../data/tseries/TSeries-03022023-1227-2098-2ch.tif"));

    public static string RGB_PATH = Path.GetFullPath(
        Path.Combine(
            TestContext.CurrentContext.TestDirectory,
            "../../../../../../data/mona.tif"));

    public static DendritePath DendritePath()
    {
        List<Pixel> pixels = new() {
            new((int)(0.4925*256), (int)(0.4912*256)),
            new((int)(0.5840*256), (int)(0.4922*256)),
            new((int)(0.6211*256), (int)(0.4277*256)),
            new((int)(0.7148*256), (int)(0.4297*256)),
            new((int)(0.8867*256), (int)(0.5039*256)),
            new((int)(0.9258*256), (int)(0.6191*256)),
            new((int)(0.9395*256), (int)(0.6855*256)),
            new((int)(0.9004*256), (int)(0.7207*256)),
        };

        DendritePath path = new(256, 256);
        foreach (Pixel pixel in pixels)
            path.Add(pixel);

        return path;
    }

    [Test]
    public void Test_Paths_Exist()
    {
        if (!File.Exists(TSERIES_2CH_PATH))
            throw new DirectoryNotFoundException(TSERIES_2CH_PATH);
    }
}
