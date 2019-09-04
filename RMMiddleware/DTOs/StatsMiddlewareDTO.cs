using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMWeb.Domain
{
    public class StatsMiddlewareDTO
    {
        public string InvokeID { get; set; }

        public long TotalResponseTime { get; set; }

        public long ResponseBodyLength { get; set; }

        public string RequestPath { get; set; }
    }
}
