using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Common.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException() { }

        public InvalidRequestException(string message) : base(message) { }
    }
}
