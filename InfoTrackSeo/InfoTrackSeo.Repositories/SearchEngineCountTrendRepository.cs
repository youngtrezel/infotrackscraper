using InfoTrackSeo.Common.DbMapping;
using InfoTrackSeo.Common.Models;
using InfoTrackSeo.Data;
using InfoTrackSeo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Repositories
{
    public class SearchEngineCountTrendRepository : ISearchEngineCountTrendRepository
    {

        private readonly SECountTrendContext _context;

        public SearchEngineCountTrendRepository(SECountTrendContext context)
        {
            _context = context;
        }

        public void AddSearchResultToDb(SearchEngineCountTrend searchEngineCountTrend)
        {
            _context.SearchEngineCountTrends.Add(DbMapping.Map(searchEngineCountTrend));

            _context.SaveChanges();
        }

        public IEnumerable<SearchEngineCountTrend> GetAllSearchEngineCountTrends()
        {
            return _context.SearchEngineCountTrends.Select(DbMapping.Map);
        }
    }
}
