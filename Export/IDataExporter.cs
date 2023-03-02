using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAnalyzer.Export
{
    public interface IDataExporter
    {
        Task ExportToCsv(List<ExportDataset> data);
        Task ExportToExcel(List<ExportDataset> data);
    }
}
