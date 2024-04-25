using FakeItEasy;
using FluentAssertions;
using InfoTrackSeo.API.Controllers;
using InfoTrackSeo.API.Handlers;
using InfoTrackSeo.API.Interfaces;
using InfoTrackSeo.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Tests.API.Controller
{
    public class InfoTrackSeoTrendsControllerTests
    {
        private readonly ISearchEngineCountHandler _searchEngineCountHandler;

        public InfoTrackSeoTrendsControllerTests()
        {
            _searchEngineCountHandler = A.Fake<SearchEngineCountHandler>();
        }

        [Fact]
        public void InfoTrackSeoTrendController_GetTrend_ReturnOk()
        {
            //Arrange 
            var controller = new InfoTrackSeoTrendsController(_searchEngineCountHandler);

            //Act
            var result = controller.GetTrend();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ActionResult<IEnumerable<SearchEngineCountTrend>>));
        }

    }
}
