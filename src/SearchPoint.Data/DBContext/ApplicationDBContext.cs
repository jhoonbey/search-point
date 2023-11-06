using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SearchPoint.Data.Entities;

namespace SearchPoint.Data.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        private readonly IConfiguration _config;

        public ApplicationDBContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Rectangle> Rectangles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedData();
            base.OnModelCreating(builder);
        }
    }
}

