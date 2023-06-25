namespace DotnetCrawlerAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URI { get; set; }
        public string Slug { get; set; }
        public double Price { get; set; }
    }
}
