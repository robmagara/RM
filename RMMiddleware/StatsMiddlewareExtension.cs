using Microsoft.AspNetCore.Builder;
using RMMiddleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMWeb.Middleware
{
    public static class StatsMiddlewareExtension
    {
        public static IApplicationBuilder UseStatsMiddleware(this IApplicationBuilder builder)
        {
            // return builder.UseMiddleware<StatsMiddleware>();
            return builder.UseMiddleware<StatsMiddlewareCollector>();
        }
    }
}
