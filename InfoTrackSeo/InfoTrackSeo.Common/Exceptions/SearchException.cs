using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Common.Exceptions
{
    public class SearchException : Exception
    {
        public SearchException() { }

        public SearchException(string message, Exception ex) : base(message, ex) { }
    }
}
