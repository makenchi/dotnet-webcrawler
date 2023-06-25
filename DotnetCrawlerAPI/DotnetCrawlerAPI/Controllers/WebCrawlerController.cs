using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCrawlerAPI.Controllers
{
    [ApiController]
    [Route("api/v1/webcrawl")]
    public class WebCrawlerController : ControllerBase
    {
        [HttpGet("{searchOrigin}")]
        public IEnumerable<string> SearchItens(string searchOrigin)
        {
            return Enumerable.Empty<string>();
        }
    }
}
