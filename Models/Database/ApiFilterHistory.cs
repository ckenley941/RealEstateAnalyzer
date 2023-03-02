using System;
using System.Collections.Generic;

namespace RealEstateAnalyzer.Models.Database
{
    public partial class ApiFilterHistory
    {
        public int ApiFilterHistoryId { get; set; }
        public DateTime? RecordDateTime { get; set; }
        public string Build { get; set; }
        public int? ReturnedRows { get; set; }
        public int? MatchingRows { get; set; }
        public string Channel { get; set; }
        public string SiteSection { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string SearchCityState { get; set; }
        public string Zip { get; set; }
        public string ListingActivity { get; set; }
        public string PropertyStatus { get; set; }
        public string PropertyType { get; set; }
        public decimal? SearchBathrooms { get; set; }
        public decimal? SearchBedrooms { get; set; }
        public decimal? SearchMaxPrice { get; set; }
        public decimal? SearchMinPrice { get; set; }
        public decimal? SearchRadius { get; set; }
        public decimal? SearchHouseSqft { get; set; }
        public decimal? SearchLotSqft { get; set; }
        public int? SearchResults { get; set; }
        public string SortResults { get; set; }
        public string SearchCoordinates { get; set; }
    }
}
