using InfoTrackSeo.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Repositories.Interfaces
{
    public interface ISearchEngineCountTrendRepository
    {
        void AddSearchResultToDb(SearchEngineCountTrend searchEngineCountTrend);

        public IEnumerable<SearchEngineCountTrend> GetAllSearchEngineCountTrends();
    }
}
