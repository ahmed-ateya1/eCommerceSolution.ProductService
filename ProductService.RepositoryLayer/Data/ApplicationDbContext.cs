using Microsoft.EntityFrameworkCore;
using ProductService.RepositoryLayer.Models;

namespace ProductService.RepositoryLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }
        public DbSet<Product> Products { get; set; }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
