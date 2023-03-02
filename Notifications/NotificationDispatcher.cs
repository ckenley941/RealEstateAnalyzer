using RealEstateAnalyzer.Emailing;
using RealEstateAnalyzer.Notifications.Processes;
using RealEstateAnalyzer.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAnalyzer.Notifications
{
    public class NotificationDispatcher: INotificationDispatcher
    {
        private readonly INotificationContainer _notificationContainer;

        public NotificationDispatcher(INotificationContainer notificationContainer)
        {
            _notificationContainer = notificationContainer;
        }

        public void SendNotifications(object stateObject)
        {
            var processKeys = stateObject as List<ServiceProcessKey>;
            if (processKeys == null)
            {
                //log invalid object type passed in
            }
            else
            {
                foreach (ServiceProcessKey processKey in processKeys)
                {
                    try
                    {
                        System.Diagnostics.Trace.WriteLine("Pre Run");
                        Task.Run(() => ProcessService(processKey));
                        System.Diagnostics.Trace.WriteLine("Post Run");
                    }
                    catch (Exception e)
                    {
                        //Log exception message and move on - we dont
                    }
                }
            }
        }

        public Task ProcessService(ServiceProcessKey processKey)
        {
            System.Diagnostics.Trace.WriteLine("Run started");
            Task serviceTask;
            switch (processKey)
            {
                case ServiceProcessKey.SendIncidentReport:
                    serviceTask = _notificationContainer.SendIncidentReport.Run();
                    break;
                case ServiceProcessKey.GetHousingData:
                    serviceTask = _notificationContainer.GetHousingData.Run();
                    break;
                default:
                    throw new ServiceProcessException("Service Process Key does not exist.");
            }

            System.Diagnostics.Trace.WriteLine("Run ended");
            return serviceTask;
        }
    }
}
