using DotnetCrawlerAPI.DTO;
using DotnetCrawlerAPI.Entities;
using DotnetCrawlerAPI.Services.Interfaces;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace DotnetCrawlerAPI.Services
{
    public class WebCrawlerService : IWebCrawlerService
    {
        public async Task<List<ProductDTO>> SearchProducts(string searchOrigin, string query)
        {
            List<ProductDTO> productsDto = new List<ProductDTO>();
            var products = getProducts(searchOrigin, query);

            foreach (var product in products)
            {
                var comments = await getComments(product.Id);

                productsDto.Add(new ProductDTO
                {
                    Product = product,
                    Comments = comments
                });
            }

            return await Task.FromResult(productsDto);
        }

        private async Task<List<Comment>> getComments(int productId)
        {
            var comments = new List<Comment>();

            var apiComments = await GetCommentsOnApi(productId.ToString());

            return apiComments;
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
                var productCard = node.SelectSingleNode("a[contains(@class,'productLink')]");
                productId = int.Parse(productCard.Attributes["data-smarthintproductid"].Value);
                var productSlug = productCard.Attributes["href"].Value;
                var productImage = productCard.SelectSingleNode("img[@class='imageCard']").Attributes["src"].Value;
                var productName = productCard.SelectSingleNode("img[@class='imageCard']").Attributes["title"].Value;
                
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
            }

            return products;
        }

        private HtmlDocument crawle(string searchOrigin)
        {
            HtmlDocument doc = new HtmlDocument();
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("User-Agent: Mozilla / 5.0(compatible; http://example.org/)");
                string origin = client.DownloadString(searchOrigin);
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(origin);

                doc = htmlDoc;
            }

            return doc;
        }

        private async Task<List<Comment>> GetCommentsOnApi(string productId)
        {
            string url = string.Format("https://servicespub.prod.api.aws.grupokabum.com.br/opinioes/v2/opinioes/{0}?limit=5", productId);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

            List<Comment> comments = new List<Comment>();

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                dynamic commentsJson = JsonConvert.DeserializeObject(json);
                if (commentsJson != null)
                {
                    foreach (var commentJson in commentsJson["opinioes"])
                    {
                        comments.Add(new Comment
                        {
                            Id = commentJson["codigo"],
                            Title = commentJson["titulo"],
                            Author = commentJson["cliente"]["nome"],
                            Text = commentJson["opiniao"],
                            ProductId = int.Parse(productId)
                        });
                    }
                }
                return comments;
            }
            else
            {
                return null;
            }
        }
    }
}
