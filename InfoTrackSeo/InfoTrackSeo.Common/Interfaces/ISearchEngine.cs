using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Core.Interfaces
{
    public interface ISearchEngine
    {
        string GetSearchAddress();
        string GetRegex();
        string GetCountDefinition();
    }
}
