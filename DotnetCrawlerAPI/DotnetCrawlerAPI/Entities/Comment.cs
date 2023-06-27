using System.ComponentModel.DataAnnotations;

namespace DotnetCrawlerAPI.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
