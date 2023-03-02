using RealEstateAnalyzer.Notifications.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAnalyzer.Notifications
{
    public interface INotificationContainer
    {
        ISendIncidentReport SendIncidentReport { get; set; }
        IGetHousingData GetHousingData { get; set; }
    }
}
