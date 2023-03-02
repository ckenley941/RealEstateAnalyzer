using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAnalyzer.Export
{
    public class DataExporter : IDataExporter
    {
        public Task ExportToCsv(List<ExportDataset> data)
        {
            if (data?.Count > 0)
            {
                var builder = new StringBuilder();
                builder.AppendLine($"{string.Join(",", data.Select(x => x.Title))},");
                int i = 0;
                var rowCt = data.FirstOrDefault().Values.Count;
                var columnCt = data.Select(x => x.Title).Count();
                while (i < rowCt)
                {
                    int j = 0;
                    List<string> rowValues = new List<string>();
                    while (j < columnCt)
                    {
                        rowValues.Add(data[j].Values[i]);
                        j++;
                    }
                    builder.AppendLine($"{string.Join(",", rowValues)},");
                    i++;
                }

                var stri = builder.ToString();
                File.WriteAllTextAsync("wrwerwer.csv", stri);
            } 
            return Task.CompletedTask;
        }

        public Task ExportToExcel(List<ExportDataset> data)
        {
            return Task.CompletedTask;
        }
    }
}
