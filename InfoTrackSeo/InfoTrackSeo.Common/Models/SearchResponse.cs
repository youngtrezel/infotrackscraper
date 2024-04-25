using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Common.Models
{
    public class SearchResponse
    {
        public required IEnumerable<int> PositionList { get; set; }
    }
}
