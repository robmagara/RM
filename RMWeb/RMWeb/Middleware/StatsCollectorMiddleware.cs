using Microsoft.AspNetCore.Http;
using RMWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMWeb.Middleware
{
    public class StatsCollectorMiddleware
    {
        private readonly RequestDelegate _next;

        public StatsCollectorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // TODO: RM 20190903 - This Works
        //public async Task InvokeAsync(HttpContext context)
        //{
        //    context.Response.Headers.Add(Guid.NewGuid().ToString().Substring(0,3), Guid.NewGuid().ToString());

        //    await _next(context);
        //}

        public async Task Invoke(HttpContext httpContext, MiddlewareDTO middlewareDto)
        {
            if (middlewareDto.InvokeIdList == null)
                middlewareDto.InvokeIdList = new List<string>();

            var invokeId = Guid.NewGuid().ToString();

            middlewareDto.InvokeIdList.Add(invokeId);

            httpContext.Response.Headers.Add(Guid.NewGuid().ToString().Substring(0, 3), invokeId);

            await _next(httpContext);
        }
    }
}
