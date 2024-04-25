using FakeItEasy;
using FluentAssertions;
using InfoTrackSeo.API.Controllers;
using InfoTrackSeo.API.Handlers;
using InfoTrackSeo.API.Interfaces;
using InfoTrackSeo.API.Validation;
using InfoTrackSeo.Common.Exceptions;
using InfoTrackSeo.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Tests.API.Controller
{
    public class InfoTrackSeoControllerTests
    {
        private readonly ISearchEngineCountHandler _searchEngineCountHandler;
        private readonly IValidate<SearchEngineRequest> _requestValidator;

        public InfoTrackSeoControllerTests() {

            _searchEngineCountHandler = A.Fake<SearchEngineCountHandler>();
            _requestValidator = A.Fake<IValidate<SearchEngineRequest>>();
           
        }

        [Fact]
        public void InfoTrackSeoController_GetSearchEngineCountAsync_ReturnOk()
        {
            //Arrange 
            var controller = new InfoTrackSeoController(_searchEngineCountHandler, _requestValidator);
            var searchEnginRequest = A.Fake<SearchEngineRequest>();

            //Act 
            var result = controller.GetSearchEngineCountAsync(searchEnginRequest);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

    }
}
