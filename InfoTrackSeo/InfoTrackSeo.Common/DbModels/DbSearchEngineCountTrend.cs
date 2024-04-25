using InfoTrackSeo.Common.Models;

namespace InfoTrackSeo.Common.DbModels
{
    public class DbSearchEngineCountTrend
    {
        public Guid Id { get; set; }
        public DateTimeOffset SearchDate { get; set; } 
        public string WordToSearch { get; set; } = string.Empty;
        public string SearchTool { get; set; } = string.Empty;
        public string UrlToFind { get; set; } = string.Empty;
        public string PositionList {  get; set; } = string.Empty;

    }
}
