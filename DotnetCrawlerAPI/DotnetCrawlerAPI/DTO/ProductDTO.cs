using DotnetCrawlerAPI.Entities;

namespace DotnetCrawlerAPI.DTO
{
    public class ProductDTO
    {
        public Product Product { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
