using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAnalyzer.Shared
{
    public class ServiceProcessException : Exception
    {
        public ServiceProcessException(string message) : base(message) { }

        public ServiceProcessException(string message, Exception innerException) : base(message, innerException) { }
    }
}
