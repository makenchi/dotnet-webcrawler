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
            List<ProductDTO> productsDto = new List<ProductDTO>();
            var products = getProducts(searchOrigin, query);

            foreach (var product in products)
            {
                productsDto.Add(new ProductDTO
                {
                    Product = product
                });
            }

            return Task.FromResult(productsDto);
        }

        private List<Comment> getComments(string productUrl)
        {
            return new List<Comment>();
        }

        private List<Product> getProducts(string searchOrigin, string query)
        {
            HtmlDocument page = crawle(string.Format("{0}{1}",searchOrigin,query));
            List<Product> products = new List<Product>();
            int productId = 0;
            //https://www.kabum.com.br/busca/ps4

            var container = page.DocumentNode.SelectSingleNode("//main");
            var nodes = container.SelectNodes("div[contains(@class,'productCard')]");

            foreach (var node in nodes)
            {
                //TODO: corrigir o xpath dos nodes, ele não está pegando  os valores corretos
                var productCard = node.SelectSingleNode("a[contains(@class,'productLink')]");
                var productSlug = productCard.Attributes["href"].Value;
                var productImage = productCard.SelectSingleNode("img[@class='imageCard']").Attributes["src"].Value;
                var productName = productCard.SelectSingleNode("img[@class='imageCard']").Attributes["title"].Value;
                //[contains(@class,'availablePricesCard')]
                var productPrice = productCard.SelectSingleNode("div")
                    .SelectSingleNode("div[contains(@class,'availablePricesCard')]")
                    .SelectSingleNode("span[contains(@class,'priceCard')]")
                    .InnerHtml;

                products.Add(new Product
                {
                    Id = productId,
                    Name = productName,
                    ImageLink = productImage,
                    Slug = productSlug,
                    Price = productPrice
                });

                productId++;
            }

            return products;
        }

        private HtmlDocument crawle(string searchOrigin)
        {
            HtmlDocument doc = new HtmlDocument();
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("User-Agent: Other");
                string origin = client.DownloadString(searchOrigin);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(origin);

                doc = htmlDoc;
            }

            return doc;
        }
    }
}
