using RealEstateAnalyzer.Notifications.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAnalyzer.Notifications
{
    public class NotificationContainer : INotificationContainer
    {
        public ISendIncidentReport SendIncidentReport { get; set; }
        public IGetHousingData GetHousingData { get; set; }

        public NotificationContainer(ISendIncidentReport sendIncidentReport, IGetHousingData getHousingData)
        {
            SendIncidentReport = sendIncidentReport;
            GetHousingData = getHousingData;
        }
    }
}
