using Microsoft.AspNetCore.Http;
using RMMiddleware;
using RMWeb.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RMWeb.Middleware
{
    public class StatsMiddleware
    {
        private readonly RequestDelegate _next;

        public StatsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, StatsMiddlewareContainerDTO statsContainer)
        {
            if (statsContainer == null)
                statsContainer = new StatsMiddlewareContainerDTO();

            if (statsContainer.StatsMiddlewareDtoList == null)
                statsContainer.StatsMiddlewareDtoList = new List<StatsMiddlewareDTO>();

            var statsMiddlewareDto = new StatsMiddlewareDTO
            {
                InvokeID = Guid.NewGuid().ToString(),
                // ResponseBodyLength = httpContext.Response.Body.Length,  NOTE: Body.Length is null here
            };


            statsContainer.StatsMiddlewareDtoList.Add(statsMiddlewareDto);
            // statsContainer.TotalResponses += 1;

            await _next(httpContext);
        }
    }
}
