using System;
using System.Collections.Generic;

namespace RealEstateAnalyzer.Models.Database
{
    public partial class Home
    {
        public Home()
        {
            HomeDetailHistory = new HashSet<HomeDetailHistory>();
        }

        public int HomeId { get; set; }
        public DateTime? RecordDateTime { get; set; }
        public int ApiFilterHistoryId { get; set; }
        public string PropertyId { get; set; }
        public string ListingId { get; set; }
        public string PropertyType { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string FullAddress { get; set; }
        public string County { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string NeighborhoodName { get; set; }
        public string PropStatus { get; set; }
        public int? BathsFull { get; set; }
        public int? Baths { get; set; }
        public int? Beds { get; set; }
        public int? BuildingSize { get; set; }
        public int? LotSize { get; set; }
        public string OfficeName { get; set; }
        public string RdcWebUrl { get; set; }

        public virtual ICollection<HomeDetailHistory> HomeDetailHistory { get; set; }
    }
}
