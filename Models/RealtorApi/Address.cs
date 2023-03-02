using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAnalyzer.Models.RealtorApi
{
    public class Address
    {
        public string city { get; set; }
        public string line { get; set; }
        public string postal_code { get; set; }
        public string state_code { get; set; }
        public string state { get; set; }
        public string county { get; set; }
        public string fips_code { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string neighborhood_name { get; set; }
    }
}
