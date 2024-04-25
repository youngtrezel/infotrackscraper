using InfoTrackSeo.API.Interfaces;
using InfoTrackSeo.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrackSeo.API.Controllers
{
    [ApiController]
    [Route("trends")]
    public class InfoTrackSeoTrendsController : ControllerBase
    {

        private readonly ISearchEngineCountHandler _searchEngineCountHandler;

        public InfoTrackSeoTrendsController(ISearchEngineCountHandler searchEngineCountHandler)
        {
            _searchEngineCountHandler = searchEngineCountHandler;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<SearchEngineCountTrend>> GetTrend()
        {
            var result = _searchEngineCountHandler.GetTrend();

            return Ok(result);  

        }

            

    }
}
