using InfoTrackSeo.Common;
using InfoTrackSeo.Common.Models;
using InfoTrackSeo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Core.CoreServices
{
    public static class SearchService
    {
        public static ISearchEngine GetSearchEngine(SearchTool searchTool) {

            return SearchEngineFactory.create(searchTool);
        }

    }
}
