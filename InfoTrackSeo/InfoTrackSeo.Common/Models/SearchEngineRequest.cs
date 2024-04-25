using System.Text.Json.Serialization;

namespace InfoTrackSeo.Common.Models
{
    public class SearchEngineRequest
    {
        public required string WordToSearch { get; set; }

        public required string UrlToFind { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SearchTool SearchTool { get; set; }
    }
}
