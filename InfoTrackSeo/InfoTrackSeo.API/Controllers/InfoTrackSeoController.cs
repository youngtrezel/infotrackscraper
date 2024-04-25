using InfoTrackSeo.API.Handlers;
using InfoTrackSeo.API.Interfaces;
using InfoTrackSeo.API.Validation;
using InfoTrackSeo.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace InfoTrackSeo.API.Controllers
{   
    [ApiController]
    [Route("search")]
    public class InfoTrackSeoController : ControllerBase
    {

        private readonly ISearchEngineCountHandler _searchEngineCountHandler;
        private readonly IValidate<SearchEngineRequest> _requestValidator;

        public InfoTrackSeoController(ISearchEngineCountHandler searchEngineCountHandler, IValidate<SearchEngineRequest> requestValidator) {

            _searchEngineCountHandler = searchEngineCountHandler;
            _requestValidator = requestValidator;
        }

        [HttpPost]
        [Route("count")]
        public ActionResult GetSearchEngineCountAsync([FromBody] SearchEngineRequest searchEngineRequest)
        {
            _requestValidator.Validate(searchEngineRequest);
            var result = _searchEngineCountHandler.GetSearchEngineCountAsync(searchEngineRequest).Result;

            return Ok(new SearchResponse { PositionList =  result });
        }
    }
}
