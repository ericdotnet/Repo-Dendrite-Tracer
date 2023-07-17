namespace ImageRatioTool.Tests;

internal class RoiIOTests
{
    [Test]
    public void Test_ROI_Save()
    {
        // create sample ROIs
        SquareRoiCollection rois = new("test path", 512, 512);
        rois.RoiCenters.AddRange(SampleData.RandomPoints(10));
        rois.MousePoints.AddRange(SampleData.RandomPoints(10));

        // simulate ROI AFU measurement
        List<double[]> afusByFrame = SampleData.RandomAfuCurves(20, rois.Count);
        rois.AfusByFrame.AddRange(afusByFrame);

        double[] frameTimes = Enumerable.Range(0, afusByFrame.Count).Select(x => (double)x * 60).ToArray();
        rois.FrameTimes.AddRange(frameTimes);

        rois.Save("roi-test.csv");
    }
}
