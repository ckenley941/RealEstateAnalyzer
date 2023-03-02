using System;
using System.Collections.Generic;

namespace RealEstateAnalyzer.Models.Database
{
    public partial class HomeDetailHistory
    {
        public int HomeDetailHistoryId { get; set; }
        public DateTime? RecordDateTime { get; set; }
        public int ApiFilterHistoryId { get; set; }
        public string PropertyId { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceChange { get; set; }
        public string LastUpdate { get; set; }
        public bool HasOpenHouse { get; set; }
        public bool IsNewListing { get; set; }
        public int? PageNo { get; set; }
        public int? Rank { get; set; }

        public virtual Home Property { get; set; }
    }
}
