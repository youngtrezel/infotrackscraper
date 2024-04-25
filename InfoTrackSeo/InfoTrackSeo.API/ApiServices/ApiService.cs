using InfoTrackSeo.Common.Models;
using InfoTrackSeo.Core.CoreServices;
using System.Web;

namespace InfoTrackSeo.API.ApiServices
{
    public static class ApiService
    {
        // Bing user agent as per https://blogs.bing.com/webmaster/april-2022/Announcing-user-agent-change-for-Bing-crawler-bingbot
        public static void AddHeader(SearchTool searchTool, HttpClient client)
        {

            switch (searchTool)
            {
                case SearchTool.Bing:

                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 AppleWebKit/537.36 (KHTML, like Gecko; compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm) Chrome/W.X.Y.Z Safari/537.36");
                    return;

                default:
                    return;

            }
        }

        public static string BuildUrl(SearchEngineRequest searchEngineRequest, string searchEngineResultsCount)
        {
            string siteUrl = SearchService.GetSearchEngine(searchEngineRequest.SearchTool).GetSearchAddress();
            string countDefintion = SearchService.GetSearchEngine(searchEngineRequest.SearchTool).GetCountDefinition();

            return $"{siteUrl}search?q={HttpUtility.UrlEncode(searchEngineRequest.WordToSearch)}&{countDefintion}={searchEngineResultsCount}";
        }

        public static string GetSearchEngineRegex(SearchEngineRequest searchEngineRequest)
        {
            return SearchService.GetSearchEngine(searchEngineRequest.SearchTool).GetRegex();
        }
    }
}
