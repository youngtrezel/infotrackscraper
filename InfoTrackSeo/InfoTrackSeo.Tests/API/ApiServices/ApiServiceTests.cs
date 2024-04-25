using InfoTrackSeo.Common.Models;
using InfoTrackSeo.Core.CoreServices;
using InfoTrackSeo.API.ApiServices;
using FakeItEasy;
using FluentAssertions;

namespace InfoTrackSeo.Tests.API.ApiServices
{
    public class ApiServiceTests
    {
        public ApiServiceTests() { }


        [Fact]
        public void ApiService_AddHeader_AddsBingHeaderForBingSearch()
        {
            //Arrange 
            var client = A.Fake<HttpClient>();

            //Act
            ApiService.AddHeader(SearchTool.Bing, client);

            //Assert
            client.DefaultRequestHeaders.Should().NotBeNull();
            Assert.Contains("Mozilla/5.0 AppleWebKit/537.36", client.DefaultRequestHeaders.UserAgent.ToString());

        }

        [Fact]
        public void ApiService_AddHeader_NoHeaderWhenNotBingSearch()
        {
            //Arrange 
            var client = A.Fake<HttpClient>();

            //Act
            ApiService.AddHeader(SearchTool.Google, client);

            //Assert
            Assert.Empty(client.DefaultRequestHeaders.UserAgent.ToString());
        }

        [Fact]
        public void ApiService_BuildUrl_ReturnsCorrectGoogleSearchUrl()
        {
            //Arrange
            var searchEngineRequest = new SearchEngineRequest
            {
                UrlToFind = "infotrack.co.uk",
                SearchTool = SearchTool.Google,
                WordToSearch = "land registry search"
            };

            var searchEngineResultsCount = "100";

            //Act
            var result = ApiService.BuildUrl(searchEngineRequest, searchEngineResultsCount);

            //Assert
            Assert.Equal("http://www.google.co.uk/search?q=land+registry+search&num=100", result);
        }

        [Fact]
        public void ApiService_BuildUrl_ReturnsCorrectBingSearchUrl()
        {
            //Arrange
            var searchEngineRequest = new SearchEngineRequest
            {
                UrlToFind = "infotrack.co.uk",
                SearchTool = SearchTool.Bing,
                WordToSearch = "land registry search"
            };

            var searchEngineResultsCount = "100";

            //Act
            var result = ApiService.BuildUrl(searchEngineRequest, searchEngineResultsCount);

            //Assert
            Assert.Equal("http://www.bing.com/search?q=land+registry+search&count=100", result);
        }

        [Fact]
        public void ApiService_GetSearchEngineRegex_ReturnsGoogleRegex()
        {
            //Arrange
            var searchEngineRequest = new SearchEngineRequest
            {
                UrlToFind = "infotrack.co.uk",
                SearchTool = SearchTool.Google,
                WordToSearch = "land registry search"
            };

            //Act
            var regex = SearchService.GetSearchEngine(searchEngineRequest.SearchTool).GetRegex();

            //Assert
            Assert.Equal(@"(?<=<div class=""egMi0 kCrYT""><a href=""/url\?q=)[^""]*", regex);
        }

        [Fact]
        public void ApiService_GetSearchEngineRegex_ReturnsBingRegex()
        {
            //Arrange
            var searchEngineRequest = new SearchEngineRequest
            {
                UrlToFind = "infotrack.co.uk",
                SearchTool = SearchTool.Bing,
                WordToSearch = "land registry search"
            };

            //Act
            var regex = SearchService.GetSearchEngine(searchEngineRequest.SearchTool).GetRegex();

            //Assert
            Assert.Equal(@"<a class=""tilk"" href=""http(.*?)""", regex);
        }

    }
}
