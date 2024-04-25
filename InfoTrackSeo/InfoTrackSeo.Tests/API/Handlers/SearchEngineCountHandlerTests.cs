using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTrackSeo.API.ApiServices;
using InfoTrackSeo.API.Interfaces;
using FakeItEasy;
using InfoTrackSeo.API.Handlers;
using InfoTrackSeo.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using InfoTrackSeo.Common;
using Microsoft.Extensions.Configuration;
using InfoTrackSeo.Common.Models;
using InfoTrackSeo.Core.CoreServices;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InfoTrackSeo.Tests.API.Handlers
{
    public class SearchEngineCountHandlerTests
    {
        private readonly HttpClient _httpClient;
        private readonly string _searchEngineResultsCount;
        private readonly ISearchEngineCountTrendRepository _repository;
        private readonly ILogger<SearchEngineCountHandler> _logger;
        private readonly IConfiguration _configuration;
        private readonly Mock<ISearchEngineCountHandler> _searchEngineCountHandler = new();
        public SearchEngineCountHandlerTests(IConfiguration config)
        {
            _httpClient = A.Fake<HttpClient>();
            _repository = A.Fake<ISearchEngineCountTrendRepository>();
            _searchEngineResultsCount = "100";
            _logger = A.Fake<ILogger<SearchEngineCountHandler>>();
            _configuration = A.Fake<IConfiguration>();

        }

        //[Fact]
        //public void SearchEngineCountHandler_GetSearchEngineCountAsync_ReturnsIEnumerable()
        //{
        //    //Arrange
        //    var searchEngineRequest = new SearchEngineRequest
        //    {
        //        UrlToFind = "infotrack.co.uk",
        //        SearchTool = SearchTool.Bing,
        //        WordToSearch = "land registry search"
        //    };

        //    Mock<IConfiguration> configuration = new Mock<IConfiguration>();
 
        //    var searchEngineCountHandler = new SearchEngineCountHandler(_httpClient, _configuration, _repository, _logger);

        //    //Act
        //    var result = searchEngineCountHandler.GetSearchEngineCountAsync(searchEngineRequest);

        //    //Assert
        //    result.Should().NotBeNull();
        //    result.Should().BeOfType(typeof(IEnumerable<int>));

        //}
    }
}
