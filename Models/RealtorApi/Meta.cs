using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAnalyzer.Models.RealtorApi
{

    public class Meta
    {
        public string build { get; set; }
        public TrackingParams tracking_params { get; set; }
        public string returned_rows { get; set; }
        public string matching_rows { get; set; }        
    }
}
