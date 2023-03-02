using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAnalyzer.Export
{
    public class ExportDataset
    {
        public ExportDataset() { }

        public ExportDataset(string title, List<string> values) { Title = title; Values = values; }

        public ExportDataset(List<ExportColumn> columns, List<ExportRow> rows) { Columns= columns; Rows = rows; }

        public string Title { get; set; } 
        public List<string> Values { get; set; }
        public List<ExportColumn> Columns { get; set; }
        public List<ExportRow> Rows { get; set; }
    }

    public class ExportColumn
    {
        public ExportColumn() { }
        public ExportColumn(string title, string dataType) { Title = title; DataType = dataType; }
        public string Title { get; set; }
        public string DataType { get; set; } //Eventually enum?
    }

    public class ExportRow
    {
        public ExportRow() { }
        public ExportRow(int index, List<string> values) { Index = index; Values = values; }
        public int Index { get; set; }
        public List<string> Values
        {
            get; set;
        }
    }
}
