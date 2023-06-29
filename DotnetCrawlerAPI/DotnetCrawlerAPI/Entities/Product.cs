using System.ComponentModel.DataAnnotations;

namespace DotnetCrawlerAPI.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public string Slug { get; set; }
        public string Price { get; set; }
    }
}
