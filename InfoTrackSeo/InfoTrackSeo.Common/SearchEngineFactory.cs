using InfoTrackSeo.Common.Exceptions;
using InfoTrackSeo.Common.Models;
using InfoTrackSeo.Core.CoreServices;
using InfoTrackSeo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Common
{
    public class SearchEngineFactory
    {
        public static ISearchEngine create(SearchTool searchTool)
        {
            switch (searchTool)
            {
                case SearchTool.Bing: 
                    return new BingSearchEngine();

                case SearchTool.Google: 
                    return new GoogleSearchEngine();

                default: throw new UnsupportedSearchEngineException(
                    $"{searchTool} is not supported as a search engine, please choose another.");
             }
        }
    }
}
