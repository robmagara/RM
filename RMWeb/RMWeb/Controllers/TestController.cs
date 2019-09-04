using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RMMiddleware;
using RMWeb.Domain;
using RMWeb.Middleware;
using RMWeb.Models;

namespace RMWeb.Controllers
{
    public class TestController : Controller
    {
        private readonly StatsMiddlewareContainerDTO _statsContainer;

        public TestController(StatsMiddlewareContainerDTO statsContainer)
        {
            _statsContainer = statsContainer;
        }

        public IActionResult Index()
        {
            var model = new StatsMiddlewareModel
            {
                StatsMiddlewareContainerDto = _statsContainer,
            };

            return View(model);
        }
    }
}