using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAnalyzer.Models.RealtorApi
{
    public class TrackingParams
    {
        public string channel { get; set; }
        public string siteSection { get; set; }
        public string city { get; set; }
        public string neighborhood { get; set; }
        public string searchcitystate { get; set; }
        public string zip { get; set; }
        public string listingactivity { get; set; }
        public string propertystatus { get; set; }
        public string propertytype { get; set; }
        public string searchbathrooms { get; set; }
        public string searchbedrooms { get; set; }
        public string searchmaxprice { get; set; }
        public string searchminprice { get; set; }
        public string searchradius { get; set; }
        public string searchhousesqft { get; set; }
        public string searchlotsqft { get; set; }
        public string searchresults { get; set; }
        public string sortresults { get; set; }
        public string searchcoordinates { get; set; }
        public string maxPrice { get; set; }
        public string offset { get; set; }
        public string radius { get; set; }
    }
}

