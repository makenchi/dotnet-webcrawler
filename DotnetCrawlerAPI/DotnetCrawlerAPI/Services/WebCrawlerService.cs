using DotnetCrawlerAPI.DTO;
using DotnetCrawlerAPI.Entities;
using DotnetCrawlerAPI.Services.Interfaces;
using HtmlAgilityPack;
using System.Net;

namespace DotnetCrawlerAPI.Services
{
    public class WebCrawlerService : IWebCrawlerService
    {
        public Task<List<ProductDTO>> SearchProducts(string searchOrigin, string query)
        {
            var products = getProducts(searchOrigin, query);

            throw new NotImplementedException();
        }

        private List<Comment> getComments(string productUrl)
        {
            return new List<Comment>();
        }

        private List<Product> getProducts(string searchOrigin, string query)
        {
            HtmlDocument page = crawle(string.Format("{0}{1}",searchOrigin,query));

            return new List<Product>();
        }

        private HtmlDocument crawle(string searchOrigin)
        {
            HtmlDocument doc = new HtmlDocument();
            using (WebClient client = new WebClient())
            {
                string origin = client.DownloadString(searchOrigin);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(origin);

                doc = htmlDoc;
            }

            return doc;
        }
    }
}
