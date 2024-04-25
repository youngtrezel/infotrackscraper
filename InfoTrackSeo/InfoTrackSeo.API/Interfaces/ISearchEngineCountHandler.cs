using InfoTrackSeo.Common.Models;

namespace InfoTrackSeo.API.Interfaces
{
    public interface ISearchEngineCountHandler
    {
        Task<IEnumerable<int>> GetSearchEngineCountAsync(SearchEngineRequest searchEngineRequest);

        IEnumerable<SearchEngineCountTrend> GetTrend();
    }
}
