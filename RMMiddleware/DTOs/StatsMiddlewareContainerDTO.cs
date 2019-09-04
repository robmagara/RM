using RMWeb.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMMiddleware
{
    public class StatsMiddlewareContainerDTO
    {
        public List<StatsMiddlewareDTO> StatsMiddlewareDtoList { get; set; }

        public double AverageResponseTime { get; set; }
        public double MinResponseTime { get; set; }
        public double MaxResponseTime { get; set; }
        public double TotalResponses { get; set; }
    }
}
