using RealEstateAnalyzer.Notifications.Processes;
using RealEstateAnalyzer.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateAnalyzer.Notifications
{
    public class NotificationService : IHostedService, IDisposable
    {
        private readonly INotificationDispatcher _notificationDispatcher;
        private Timer _timer;
        private const int _serviceTimerMinutes = 300; //Eventually made configurable

        public NotificationService(INotificationDispatcher notificationDispatcher)
        {
            _notificationDispatcher = notificationDispatcher;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Timed Background Service is starting.");            
            TimerCallback timerDelegate = new TimerCallback(_notificationDispatcher.SendNotifications);
            _timer = new Timer(timerDelegate, LoadData(), 3000, _serviceTimerMinutes * 60000);

            return Task.CompletedTask;
        }

        //Move to its own class
        //Eventually pull from a database table of Schedule records ready to process
        private List<ServiceProcessKey> LoadData()
        {
            return new List<ServiceProcessKey>() { ServiceProcessKey.SendIncidentReport, ServiceProcessKey.GetHousingData };
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Timed Background Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}