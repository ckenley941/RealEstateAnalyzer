using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAnalyzer.Models.RealtorApi
{
    public class RealtorApiResponse
    {
        public Meta meta { get; set; }
        public List<Property> properties { get; set; }
    }
}
