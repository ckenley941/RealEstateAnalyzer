using RealEstateAnalyzer.Models.Database;
using RealEstateAnalyzer.Models.RealtorApi;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RealEstateAnalyzer.Shared
{
    public static class SelectTo
    {
        public static ApiFilterHistory NewApiFilterHistory(Meta meta, TrackingParams filter)
        {
            return new ApiFilterHistory()
            {
                RecordDateTime = DateTime.Now,
                Build = meta.build,
                ReturnedRows = meta.returned_rows.ToInt(),
                MatchingRows = meta.returned_rows.ToInt(),
                Channel = meta.tracking_params.channel,
                SiteSection = meta.tracking_params.siteSection,
                City = meta.tracking_params.city,
                Neighborhood = filter.neighborhood,
                SearchCityState = meta.tracking_params.searchcitystate,
                Zip = filter.zip,
                ListingActivity = meta.tracking_params.listingactivity,
                PropertyStatus = meta.tracking_params.propertystatus,
                PropertyType = meta.tracking_params.propertytype,
                SearchBathrooms = meta.tracking_params.searchbathrooms.ToDecimal(),
                SearchBedrooms = meta.tracking_params.searchbedrooms.ToDecimal(),
                SearchMaxPrice = meta.tracking_params.searchmaxprice.ToDecimal(),
                SearchMinPrice = meta.tracking_params.searchminprice.ToDecimal(),
                SearchRadius = meta.tracking_params.searchradius.ToDecimal(),
                SearchHouseSqft = meta.tracking_params.searchhousesqft.ToDecimal(),
                SearchLotSqft = meta.tracking_params.searchlotsqft.ToDecimal(),
                SearchResults = meta.tracking_params.searchresults.ToInt(),
                SortResults = meta.tracking_params.sortresults,
                SearchCoordinates = meta.tracking_params.searchcoordinates
            };
        }

        public static Home NewHome(Property property, int apiFilterHistoryId)
        {
            return new Home()
            {
                ApiFilterHistoryId = apiFilterHistoryId,
                RecordDateTime = DateTime.Now,
                PropertyId = property.property_id,
                ListingId = property.listing_id,
                PropertyType = property.prop_type,
                Street = property.address.line,
                City = property.address.city,
                PostalCode = property.address.postal_code,
                State = property.address.state,
                FullAddress = $"{property.address.line} {property.address.city}, {property.address.state} {property.address.postal_code}",
                County = property.address.county,
                Latitude = property.address.lat,
                Longitude = property.address.lon,
                NeighborhoodName = property.address.neighborhood_name,
                PropStatus = property.prop_status,                
                BathsFull = property.baths_full.ToInt(),
                Baths = property.baths.ToInt(),
                Beds = property.beds.ToInt(),
                BuildingSize = property.building_size?.size.ToInt(),
                OfficeName = property.office?.name,
                RdcWebUrl = property.rdc_web_url,
                LotSize = property.lot_size?.size.ToInt(),                
            };
        }

        public static HomeDetailHistory NewHomeDetailHistory(Property property, int apiFilterHistoryId)
        {
            return new HomeDetailHistory()
            {
                RecordDateTime = DateTime.Now,
                ApiFilterHistoryId = apiFilterHistoryId,
                PropertyId = property.property_id,
                Price = property.price.ToDecimal(),
                PriceChange = property.client_display_flags.price_change.ToInt(),
                LastUpdate = property.last_update,
                HasOpenHouse = property.client_display_flags.has_open_house.ToBoolean(),
                IsNewListing = property.client_display_flags.is_new_listing.ToBoolean(),
                PageNo = property.page_no.ToInt(),
                Rank = property.rank.ToInt()
            };
        }
    }

}
