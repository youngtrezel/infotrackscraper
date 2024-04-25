using InfoTrackSeo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Common
{
    public class BingSearchEngine : ISearchEngine
    {
        public string GetCountDefinition()
        {
            return "count";
        }

        public string GetRegex()
        {
            return @"<a class=""tilk"" href=""http(.*?)""";
        }

        public string GetSearchAddress()
        {
            return $"http://www.bing.com/";
        }
    }
}
