namespace DotnetCrawlerAPI.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public int ProductId { get; set; }
    }
}
