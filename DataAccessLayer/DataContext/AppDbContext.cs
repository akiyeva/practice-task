using DataAccessLayer.DataContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}