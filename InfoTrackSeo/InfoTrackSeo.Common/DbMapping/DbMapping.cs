using InfoTrackSeo.Common.DbModels;
using InfoTrackSeo.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Common.DbMapping
{
    public static class DbMapping
    {

        public static SearchEngineCountTrend Map(SearchEngineRequest searchEngineRequest, IEnumerable<int> positionList)
        {
            return new SearchEngineCountTrend
            {
                Id = Guid.NewGuid(),
                SearchDate = DateTimeOffset.Now,
                WordToSearch = searchEngineRequest.WordToSearch,
                SearchTool = searchEngineRequest.SearchTool,
                UrlToFind = searchEngineRequest.UrlToFind,
                PositionList = positionList
            };
        }

        public static SearchEngineCountTrend Map(DbSearchEngineCountTrend dbSearchEngineCountTrend)
        {
            if(!Enum.TryParse(dbSearchEngineCountTrend.SearchTool, out SearchTool searchTool))
            {
                throw new InvalidCastException("Search engine not recognised.");

            } else
            {
                return new SearchEngineCountTrend {
                    Id = dbSearchEngineCountTrend.Id,
                    SearchDate = dbSearchEngineCountTrend.SearchDate,
                    WordToSearch = dbSearchEngineCountTrend.WordToSearch,
                    SearchTool = searchTool,
                    UrlToFind = dbSearchEngineCountTrend.UrlToFind,
                    PositionList = dbSearchEngineCountTrend.PositionList.Split(',').Select(int.Parse)
                };
   
            }
        }

        public static DbSearchEngineCountTrend Map(SearchEngineCountTrend searchEngineCountTrend)
        {
            
            return new DbSearchEngineCountTrend
            {
                Id = searchEngineCountTrend.Id,
                SearchDate = searchEngineCountTrend.SearchDate,
                WordToSearch = searchEngineCountTrend.WordToSearch,
                SearchTool = searchEngineCountTrend.SearchTool.ToString(),
                UrlToFind = searchEngineCountTrend.UrlToFind,
                PositionList = string.Join(",", searchEngineCountTrend.PositionList.Select(x => x.ToString()))
            };

            
        }

    }
}
