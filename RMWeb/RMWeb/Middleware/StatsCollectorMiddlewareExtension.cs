using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMWeb.Middleware
{
    public static class StatsCollectorMiddlewareExtension
    {
        public static IApplicationBuilder UseStatsCollectorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StatsCollectorMiddleware>();
        }
    }
}
