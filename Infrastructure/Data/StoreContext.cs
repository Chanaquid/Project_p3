using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Category {get; set;}
        public DbSet<ProductBrand> ProductBrand {get; set;}
        
    }

}