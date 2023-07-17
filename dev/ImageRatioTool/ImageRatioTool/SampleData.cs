namespace ImageRatioTool;

public static class SampleData
{
    public static string RatiometricImage => GetSampleDataFile("2ch-baseline.tif");
    public static string RatiometricImageSeries => GetSampleDataFile("TSeries-03022023-1227-2098-2ch.tif");
    public static string RatiometricImageSeriesXML => GetSampleDataFile("TSeries-03022023-1227-2098.xml");
    public static string FixedTif => GetSampleDataFile("TSeries-06022023-1246-2207 FIXED.tif");

    public static string GetSampleDataFile(string filename)
    {
        string localFolder = Path.GetFullPath("./");
        string localPath = Path.Combine(localFolder, filename);
        if (File.Exists(localPath))
            return Path.GetFullPath(localPath);

        string sampleDataFolderSingle = Path.Join(
            path1: Application.StartupPath,
            path2: "../../../../../data/single");
        string sampleDataFolderPath = Path.Combine(sampleDataFolderSingle, filename);
        if (File.Exists(sampleDataFolderPath))
            return Path.GetFullPath(sampleDataFolderPath);

        string sampleDataFolderTSeries = Path.Join(
            path1: Application.StartupPath,
            path2: "../../../../../data/tseries");
        string sampleDataFolderTSeriesPath = Path.Combine(sampleDataFolderTSeries, filename);
        if (File.Exists(sampleDataFolderTSeriesPath))
            return Path.GetFullPath(sampleDataFolderTSeriesPath);

        string networkFolder = Path.GetFullPath("X:\\zTemp\\2p sample data");
        string networkFolderPath = Path.Combine(networkFolder, filename);
        if (File.Exists(networkFolderPath))
            return Path.GetFullPath(networkFolderPath);

        throw new InvalidOperationException("sample data file not found");
    }
}
