using DotnetCrawlerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetCrawlerAPI.Infra.Data
{
    public class SqlContext : DbContext
    {
        private readonly string connectionString;
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
