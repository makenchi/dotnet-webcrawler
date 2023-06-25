using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCrawlerAPI.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class WebCrawlerController : ControllerBase
    {
        [HttpGet("webcrawl")]
        public IEnumerable<string> SearchItens(string searchOrigin, string query)
        {
            return Enumerable.Empty<string>();
        }
    }
}
