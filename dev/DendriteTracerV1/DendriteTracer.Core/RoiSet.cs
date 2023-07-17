namespace DendriteTracer.Core;

public class RoiSet
{
    readonly List<Pixel> Points = new();

    public void Add(Pixel pixel)
    {
        Points.Add(pixel);
    }

    public void AddRange(IEnumerable<Pixel> pixels)
    {
        Points.AddRange(pixels);
    }

    public void Clear()
    {
        Points.Clear();
    }

    public void Draw(Bitmap bmp)
    {
        foreach (Pixel px in Points)
        {
            Rectangle rect = new(px, 5);
            bmp.DrawRect(rect, Colors.Magenta);
        }
    }
}
