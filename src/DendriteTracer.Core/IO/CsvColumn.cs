namespace DendriteTracer.Core.IO;

public class CsvColumn
{
    public string Name { get; set; } = string.Empty;
    public string Units { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
    public List<string> Cells { get; } = new();

    public void AddCells(double[] values)
    {
        foreach (double value in values)
        {
            AddCell(value);
        }
    }

    public void AddCell(double value, int precision = 5)
    {
        Cells.Add(Math.Round(value, precision).ToString());
    }

    public void AddCells(string[] values)
    {
        foreach (string value in values)
        {
            AddCell(value);
        }
    }

    public void AddCell(string value)
    {
        Cells.Add($"{value}");
    }
}
