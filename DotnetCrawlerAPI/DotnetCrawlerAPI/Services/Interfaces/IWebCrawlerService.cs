using DotnetCrawlerAPI.DTO;

namespace DotnetCrawlerAPI.Services.Interfaces
{
    public interface IWebCrawlerService
    {
        Task<List<ProductDTO>> SearchProducts(string query);
    }
}
