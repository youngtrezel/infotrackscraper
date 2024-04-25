using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfoTrackSeo.Common.Models
{
    public class SearchEngineCountTrend
    {
        public Guid Id { get; set; }
        public DateTimeOffset SearchDate { get; set; }
        public string WordToSearch { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SearchTool SearchTool { get; set; }
        public string UrlToFind { get; set; } = string.Empty;
        public IEnumerable<int> PositionList { get; set; } = Enumerable.Empty<int>();
    }
}
