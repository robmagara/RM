using Microsoft.AspNetCore.Http;
using RMMiddleware;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RMMiddlewareTests
{
    public class test_StatsMiddlewareCollector
    {
        private StatsMiddlewareCollector _statsCollector;
        private StatsMiddlewareContainerDTO _statsContainer;

        public test_StatsMiddlewareCollector()
        {
            _statsContainer = new StatsMiddlewareContainerDTO();
        }

        [Fact]
        public async Task test_StatsCollector_CreatesResponse()
        {
            var defaultHttpContext = new DefaultHttpContext();

            _statsCollector = new StatsMiddlewareCollector(
                next: async (httpContext) =>
                {

                });

            await _statsCollector.Invoke(defaultHttpContext, _statsContainer);

            Assert.True(_statsContainer.TotalResponses > 0);
        }

        [Fact]
        public async Task test_StatsCollector_HasListOfStats()
        {
            var defaultHttpContext = new DefaultHttpContext();

            _statsCollector = new StatsMiddlewareCollector(
                next: async (httpContext) =>
                {

                });

            await _statsCollector.Invoke(defaultHttpContext, _statsContainer);

            Assert.True(_statsContainer.StatsMiddlewareDtoList.Any());
        }
    }
}
