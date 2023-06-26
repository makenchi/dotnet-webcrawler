using DotnetCrawlerAPI.DTO;
using DotnetCrawlerAPI.Entities;
using DotnetCrawlerAPI.Services.Interfaces;
using HtmlAgilityPack;

namespace DotnetCrawlerAPI.Services
{
    public class WebCrawlerService : IWebCrawlerService
    {
        public async Task<List<ProductDTO>> SearchProducts(string searchOrigin, string query)
        {
            throw new NotImplementedException();
        }

        private List<Comment> getComments(string productUrl)
        {
            return new List<Comment>();
        }

        private List<Product> getProducts(string searchOrigin, string query)
        {
            return new List<Product>();
        }

        private HtmlDocument crawle(string searchOrigin)
        {
            return new HtmlDocument();
        }
    }
}
