using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RMMiddleware;
using RMWeb.Domain;

namespace RMWeb.Controllers
{
    public class Test2Controller : Controller
    {
        private readonly StatsMiddlewareContainerDTO _statsContainer;

        public Test2Controller(StatsMiddlewareContainerDTO statsContainer)
        {
            _statsContainer = statsContainer;
        }

        public IActionResult Index()
        {
            var response = HttpContext.Response;

            return View();
        }
    }
}