using Newtonsoft.Json;
using RealEstateAnalyzer.Export;
using RealEstateAnalyzer.Models.Database;
using RealEstateAnalyzer.Models.RealtorApi;
using RealEstateAnalyzer.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Transactions;

namespace RealEstateAnalyzer.Notifications.Processes
{
    public class GetHousingData : IGetHousingData
    {
        private readonly RealEstateAnalyzerContext _dbContext;
        private readonly IDataExporter _dataExport;

        public GetHousingData(RealEstateAnalyzerContext dbContext, IDataExporter dataExport)
        {
            _dbContext = dbContext;
            _dataExport = dataExport;
        }

        public Task Run()
        {
            return CallRealtorApi();
        }

        private Task CallRealtorApi()
        {
            var filters = new List<TrackingParams>();

            filters.Add(new TrackingParams()
            {
                searchbedrooms = "3",
                searchbathrooms = "2",
                propertytype = "single_family",
                maxPrice = "600000",
                zip = "80211",
                offset = "0",
                neighborhood = "Highland, Jeff Park, Sunnyside"
            });
            filters.Add(new TrackingParams()
            {
                searchbedrooms = "3",
                searchbathrooms = "2",
                propertytype = "single_family",
                maxPrice = "600000",
                zip = "80212",
                radius = "20",
                offset = "0",
                neighborhood = "Berkley, Moutain View"
            });
            filters.Add(new TrackingParams()
            {
                searchbedrooms = "3",
                searchbathrooms = "2",
                propertytype = "single_family",
                maxPrice = "600000",
                zip = "80219",
                radius = "20",
                offset = "0",
                neighborhood="SE Lakewood"
            });
            filters.Add(new TrackingParams()
            {
                searchbedrooms = "3",
                searchbathrooms = "2",
                propertytype = "single_family",
                maxPrice = "600000",
                zip = "80214",
                radius = "20",
                offset = "0",
                neighborhood="W Colfax"
            });

            filters.Add(new TrackingParams()
            {
                searchbedrooms = "3",
                searchbathrooms = "2",
                propertytype = "single_family",
                maxPrice = "600000",
                zip = "80226",
                radius = "20",
                offset = "0",
                neighborhood = "Lakewood"
            });

            filters.Add(new TrackingParams()
            {
                searchbedrooms = "3",
                searchbathrooms = "2",
                propertytype = "single_family",
                maxPrice = "600000",
                zip = "80204",
                radius = "20",
                offset = "0",
                neighborhood= "W Colfax, Lincoln"
            });

            filters.Add(new TrackingParams()
            {
                searchbedrooms = "3",
                searchbathrooms = "2",
                propertytype = "single_family",
                maxPrice = "600000",
                zip = "80033",
                radius = "20",
                offset = "0",
                neighborhood="Wheat Ridge"
            });

            filters.Add(new TrackingParams()
            {
                searchbedrooms = "3",
                searchbathrooms = "2",
                propertytype = "single_family",
                maxPrice = "600000",
                zip = "80209",
                radius = "20",
                offset = "0",
                neighborhood = "Wash Park"
            });

            filters.Add(new TrackingParams()
            {
                searchbedrooms = "3",
                searchbathrooms = "2",
                propertytype = "single_family",
                maxPrice = "600000",
                zip = "80203",
                radius = "20",
                offset = "0",
                neighborhood = "Cap Hill"
            });           

            //int pageNo = 1;
            //int pages = 5;
            //while (pageNo < (pages + 1))
            //{
            //    filters.Add(new TrackingParams()
            //    {
            //        searchbedrooms = "3",
            //        searchbathrooms = "2",
            //        propertytype = "single_family",
            //        maxPrice = "600000",
            //        city = "Denver",
            //        searchcitystate = "CO",
            //        offset = $"{pageNo * 200}"
            //    });
            //    pageNo++;
            //}

            //pageNo = 1;
            //pages = 5;
            //while (pageNo < (pages + 1))
            //{
            //    filters.Add(new TrackingParams()
            //    {
            //        searchbedrooms = "3",
            //        searchbathrooms = "2",
            //        propertytype = "single_family",
            //        maxPrice = "600000",
            //        city = "Lakewood",
            //        searchcitystate = "CO",
            //        offset = $"{pageNo * 200}"
            //    });
            //    pageNo++;
            //}

            //pageNo = 1;
            //pages = 1;
            //while (pageNo < (pages + 1))
            //{
            //    filters.Add(new TrackingParams()
            //    {
            //        searchbedrooms = "3",
            //        searchbathrooms = "2",
            //        propertytype = "single_family",
            //        maxPrice = "600000",
            //        city = "Edgewater",
            //        searchcitystate = "CO",
            //        offset = $"{pageNo * 200}"
            //    });
            //    pageNo++;
            //}

            //pageNo = 1;
            //pages = 1;
            //while (pageNo < (pages + 1))
            //{
            //    filters.Add(new TrackingParams()
            //    {
            //        searchbedrooms = "3",
            //        searchbathrooms = "2",
            //        propertytype = "single_family",
            //        maxPrice = "600000",
            //        city = "Edgewater",
            //        searchcitystate = "CO",
            //        offset = $"{pageNo * 200}"
            //    });
            //    pageNo++;
            //}
            foreach (var filter in filters)
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("x-rapidapi-host", "realtor.p.rapidapi.com");
                    client.DefaultRequestHeaders.Add("x-rapidapi-key", "97072ef5f8msh4349da9bb755f07p10511bjsn8836fe922fc6");
                    try
                    {
                        string url = "";
                        if (!string.IsNullOrEmpty(filter.searchcitystate))
                        {
                            url = $"https://realtor.p.rapidapi.com/properties/v2/list-for-sale?beds_min={filter.searchbedrooms}&" +
                                $"sort=relevance&prop_type={filter.propertytype}&baths_min={filter.searchbathrooms}&price_max={filter.maxPrice}&" +
                                $"city={filter.city}&limit=200&offset={filter.offset}&state_code={filter.searchcitystate}";
                        }
                        else
                        {
                            url = $"https://realtor.p.rapidapi.com/properties/v2/list-for-sale?beds_min={filter.searchbedrooms}&" +
                                $"sort=relevance&prop_type={filter.propertytype}&baths_min={filter.searchbathrooms}&price_max={filter.maxPrice}&" +
                                $"postal_code={filter.zip}&limit=200&offset={filter.offset}";
                        }
                        var responseMessage = client.GetAsync(url).Result;
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            var stringResult = responseMessage.Content.ReadAsStringAsync().Result;
                            var responseData = JsonConvert.DeserializeObject<RealtorApiResponse>(stringResult);
                            if (responseData != null)
                            {
                                SaveToDatabase(responseData, filter);
                                ExportData(responseData, ExportType.Csv);
                            }
                            else
                            {
                                //TODO log
                                throw new ServiceProcessException($"Failed to deserialize {stringResult}");
                            }
                        }
                        else
                        {
                            //TODO log
                            throw new ServiceProcessException($"Failed to get data from URL: {url}");
                        }
                    }
                    catch (Exception e)
                    {
                        //TODO log
                        throw e;
                    }
                }
                //var responseData = new RealtorApiResponse() {
                //    properties = new List<Property>()
                //    {
                //        new Property(){
                //            property_id = "test",
                //            price = "100"
                //        },new Property(){
                //            property_id = "test2",
                //            price = "200"
                //        },new Property(){
                //            property_id = "test3",
                //            price = "300"
                //        },

                //    }
                //};
            }

            //ExportData(responseData, ExportType.Csv);
            return Task.CompletedTask;
        }

        private void SaveToDatabase(RealtorApiResponse responseData, TrackingParams filter)
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    var apiFilterHistory = SelectTo.NewApiFilterHistory(responseData.meta, filter);
                    _dbContext.ApiFilterHistory.Add(apiFilterHistory);
                    _dbContext.SaveChanges();

                    IEnumerable<string> existingPropertyIds = _dbContext.Home.Select(x => x.PropertyId);

                    responseData.properties.ForEach(x =>
                    {
                        //Add home if it doesn't exist
                        if (!existingPropertyIds.Contains(x.property_id))
                        {
                            _dbContext.Home.Add(SelectTo.NewHome(x, apiFilterHistory.ApiFilterHistoryId));
                        }

                        //Always add details
                        _dbContext.HomeDetailHistory.Add(SelectTo.NewHomeDetailHistory(x, apiFilterHistory.ApiFilterHistoryId));
                    });
                    _dbContext.SaveChanges();
                    scope.Complete();
                }
            }
            catch (Exception e)
            {
                //Log exception
            }
        }

        private void ExportData(RealtorApiResponse responseData, ExportType exportType)
        {
           // responseData.properties.ToExportDataSet();
            List<ExportDataset> exportData = new List<ExportDataset>();

            exportData.Add(new ExportDataset("Property Id", responseData.properties.Select(x => x.property_id).ToList()));
            exportData.Add(new ExportDataset("Price", responseData.properties.Select(x => x.price).ToList()));

            switch (exportType)
            {
                case ExportType.Csv:
                    _dataExport.ExportToCsv(exportData);
                    break;
                case ExportType.Excel:
                    _dataExport.ExportToExcel(null);
                    break;
            }
        }


        private List<(string title, string propertyName)> GetColumnsToExport()
        {
            return new List<(string, string)>()
            {
                ("Property Id", nameof(Property.property_id)),
                ("Price", nameof(Property.price))
            };
        }

    }
}
