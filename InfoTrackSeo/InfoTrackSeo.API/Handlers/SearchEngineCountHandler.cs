using InfoTrackSeo.API.ApiServices;
using InfoTrackSeo.API.Interfaces;
using InfoTrackSeo.Common;
using InfoTrackSeo.Common.Models;
using InfoTrackSeo.Core.CoreServices;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Linq;
using Microsoft.Extensions.FileSystemGlobbing;
using InfoTrackSeo.Repositories.Interfaces;
using InfoTrackSeo.Common.DbMapping;
using InfoTrackSeo.Common.Exceptions;


namespace InfoTrackSeo.API.Handlers
{
    public class SearchEngineCountHandler : ISearchEngineCountHandler
    {
        private readonly HttpClient _httpClient;
        private readonly string _searchEngineResultsCount;
        private readonly ISearchEngineCountTrendRepository _repository;
        private readonly ILogger<SearchEngineCountHandler> _logger;

        public SearchEngineCountHandler(HttpClient httpClient, IConfiguration config, ISearchEngineCountTrendRepository repository, ILogger<SearchEngineCountHandler> logger) {

            _httpClient = httpClient;
            _repository = repository;
            _searchEngineResultsCount = config.GetSection("SearchEngineDefaultCount").Value ?? Constants.SearchCountDefault;
            _logger = logger;
        }

        public async Task<IEnumerable<int>> GetSearchEngineCountAsync(SearchEngineRequest searchEngineRequest)  {

            string url = ApiService.BuildUrl(searchEngineRequest, _searchEngineResultsCount);
            ApiService.AddHeader(searchEngineRequest.SearchTool, _httpClient);

            var resultsToParse = new List<int>();
            try
            {
                var response = await _httpClient.GetStringAsync(url);

                resultsToParse = ParseReturnedResults(ApiService.GetSearchEngineRegex(searchEngineRequest), response, searchEngineRequest.UrlToFind).ToList();
                _logger.LogInformation($"Using {searchEngineRequest.SearchTool} user searched for \"{searchEngineRequest.WordToSearch}\" to match URL \"{searchEngineRequest.UrlToFind}\"");
            } 
            catch (Exception ex)
            {
                throw new SearchException("There was an internal error during the search", ex);
            }

            resultsToParse = resultsToParse.Count != 0 ? resultsToParse : [0];
            AddResultsToDb(searchEngineRequest, resultsToParse);

            return resultsToParse.Count != 0 ? resultsToParse : [0];
        }

        private void AddResultsToDb(SearchEngineRequest request, IEnumerable<int> positionList)
        {
            _repository.AddSearchResultToDb(DbMapping.Map(request, positionList));
        }

        private static IEnumerable<int> ParseReturnedResults(string regex, string html, string urlToMatch)
        {
            var results = new List<int>();
            var matched = Regex.Matches(html, regex);

            int count = 1;

            foreach (Match match in matched)
            {
                if (match.Groups[0].Value.Contains(urlToMatch))
                {
                    results.Add(count);
                }
                count++;
            }

            return results;
        }

        public IEnumerable<SearchEngineCountTrend> GetTrend()
        {
            return _repository.GetAllSearchEngineCountTrends();
        }
    }
}
