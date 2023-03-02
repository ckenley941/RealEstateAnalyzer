using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAnalyzer.Notifications
{
    public interface INotificationDispatcher
    {
        void SendNotifications(object stateObject);
    }
}
