using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAnalyzer.Notifications.Processes
{
    public class ServiceProcess: IServiceProcess
    {
        private readonly IServiceJob _serviceJob;

        public ServiceProcess(IServiceJob serviceJob)
        {
            _serviceJob = serviceJob;
        }

        public Task Execute()
        {
            return _serviceJob.Run();
        }
    }
}
