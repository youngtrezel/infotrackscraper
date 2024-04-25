using InfoTrackSeo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Core.CoreServices
{
    public class GoogleSearchEngine : ISearchEngine
    {
        public string GetCountDefinition()
        {
            return "num";
        }

        public string GetRegex()
        {
            return @"(?<=<div class=""egMi0 kCrYT""><a href=""/url\?q=)[^""]*";
        }

        public string GetSearchAddress()
        {
            return $"http://www.google.co.uk/";
        }
    }
}
