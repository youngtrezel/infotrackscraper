using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Common.Exceptions
{
    public class UnsupportedSearchEngineException : Exception
    {
        public UnsupportedSearchEngineException() { }

        public UnsupportedSearchEngineException(string message) : base(message) { }
    }
}
