using RealEstateAnalyzer.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAnalyzer.Models.RealtorApi
{
    public class Property
    {
        [ExportColumnAttribute("Property Id")]
        public string property_id { get; set; }
        public string listing_id { get; set; }
        public string rdc_web_url { get; set; }
        public string prop_type { get; set; }
        public Address address { get; set; }
        public string prop_status { get; set; }
        [ExportColumnAttribute("Price")]
        public string price { get; set; }
        public string baths_full { get; set; }
        public string baths { get; set; }
        public string beds { get; set; }
        public PropertySize building_size { get; set; }
        public Office office { get; set; }
        public string last_update { get; set; }
        public ClientDisplayFlags client_display_flags { get; set; }
        public string page_no { get; set; }
        public string rank { get; set; }
        public PropertySize lot_size { get; set; }
    }
}
