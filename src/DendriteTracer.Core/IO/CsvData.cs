using System.Text;

namespace DendriteTracer.Core.IO;

public class CsvData
{
    private readonly List<CsvColumn> CsvColumns = new();

    public CsvData()
    {
    }

    public void AddCol(CsvColumn col)
    {
        CsvColumns.Add(col);
    }

    public void AddCol(double[] values, string? name = null, string? units = null, string? comments = null)
    {
        CsvColumn col = new()
        {
            Name = name ?? string.Empty,
            Units = units ?? string.Empty,
            Comments = comments ?? string.Empty,
        };

        col.AddCells(values);

        CsvColumns.Add(col);
    }

    public string GetCsvText(string delimiter = "\t")
    {
        StringBuilder sb = new();

        sb.AppendLine(string.Join(delimiter, CsvColumns.Select(x => $"{x.Name}")));
        sb.AppendLine(string.Join(delimiter, CsvColumns.Select(x => $"{x.Units}")));
        sb.AppendLine(string.Join(delimiter, CsvColumns.Select(x => $"{x.Comments}")));

        int maxDataRows = CsvColumns.Any() ? CsvColumns.Select(x => x.Cells.Count).Max() : 0;

        for (int rowIndex = 0; rowIndex < maxDataRows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < CsvColumns.Count; colIndex++)
            {
                if (CsvColumns[colIndex].Cells.Count > rowIndex)
                {
                    sb.Append($"{CsvColumns[colIndex].Cells[rowIndex]}");
                }
                else
                {
                    sb.Append($"");
                }

                if (colIndex < CsvColumns.Count - 1)
                {
                    sb.Append(delimiter);
                }
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }

    public void Save(string saveAs, string delimiter = "\t")
    {
        File.WriteAllText(saveAs, GetCsvText(delimiter));
    }
}