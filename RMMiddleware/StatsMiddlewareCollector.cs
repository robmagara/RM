using Microsoft.AspNetCore.Http;
using RMWeb.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMiddleware
{
    public class StatsMiddlewareCollector
    {
        RequestDelegate _next;

        public StatsMiddlewareCollector(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, StatsMiddlewareContainerDTO statsContainer)
        {
            using (var buffer = new MemoryStream())
            {
                var request = context.Request;
                var response = context.Response;

                var bodyStream = response.Body;
                response.Body = buffer;

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                await _next(context);

                stopwatch.Stop();

                if (statsContainer == null)
                    statsContainer = new StatsMiddlewareContainerDTO();

                if (statsContainer.StatsMiddlewareDtoList == null)
                    statsContainer.StatsMiddlewareDtoList = new List<StatsMiddlewareDTO>();

                lock (statsContainer)
                {
                    var statsMiddlewareDto = new StatsMiddlewareDTO
                    {
                        InvokeID = Guid.NewGuid().ToString(),
                        ResponseBodyLength = response.ContentLength ?? buffer.Length,
                        TotalResponseTime = stopwatch.ElapsedMilliseconds,
                        RequestPath = context.Request.Path,
                        DateCreated = DateTime.Now,
                    };

                    statsContainer.StatsMiddlewareDtoList.Add(statsMiddlewareDto);
                    statsContainer.TotalResponses += 1;
                    statsContainer.AverageResponseTime = statsContainer.StatsMiddlewareDtoList.Average(x => x.TotalResponseTime);
                    statsContainer.MaxResponseTime = statsContainer.StatsMiddlewareDtoList.Max(x => x.TotalResponseTime);
                    statsContainer.MinResponseTime = statsContainer.StatsMiddlewareDtoList.Min(x => x.TotalResponseTime);
                }

                buffer.Position = 0;

                await buffer.CopyToAsync(bodyStream);
            }
        }
    }
}
