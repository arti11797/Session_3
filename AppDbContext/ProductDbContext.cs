using Microsoft.EntityFrameworkCore;
using Session3.Models;

namespace Session3.AppDbContext
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext>Context):base(Context)
        {
        
        }

        public DbSet<Product> Products { get; set; }

    }
}
