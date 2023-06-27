using DotnetCrawlerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetCrawlerAPI.Infra.Data
{
    public class SqlContext : DbContext
    {
        private readonly string connectionString;
        public SqlContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
