using DotnetCrawlerAPI.DTO;
using DotnetCrawlerAPI.Services.Interfaces;

namespace DotnetCrawlerAPI.Services
{
    public class WebCrawlerService : IWebCrawlerService
    {
        public Task<List<ProductDTO>> SearchProducts(string searchOrigin, string query)
        {
            throw new NotImplementedException();
        }
    }
}
