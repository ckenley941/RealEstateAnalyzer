﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAnalyzer.Notifications.Processes
{
    public interface IServiceJob
    {
        Task Run();
    }
}
