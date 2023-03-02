using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAnalyzer.Shared
{
    public sealed class ExportColumnAttribute : Attribute
    {
        private readonly string _title;
        public ExportColumnAttribute(string title)
        {
           _title = title;
        }

        public string Title { get { return _title; } }
}
}
