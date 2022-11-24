using Microsoft.EntityFrameworkCore;

namespace ThAmCo.Products.WebApp.Models
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }

        private readonly IHostEnvironment _hostEnv;

        public ProductsContext(DbContextOptions<ProductsContext> options,
                    IHostEnvironment env) : base(options)
        {
            _hostEnv = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Product1", Price = 4.5, Quantity = 5, Description = "The first product" },
                new Product { ProductId = 2, ProductName = "Product2", Price = 5.5, Quantity = 10, Description = "The second product" },
                new Product { ProductId = 3, ProductName = "Product3", Price = 10.2, Quantity = 2, Description = "The third product" },
                new Product { ProductId = 4, ProductName = "Product4", Price = 12.5, Quantity = 6, Description = "The fourth product" },
                new Product { ProductId = 5, ProductName = "Product5", Price = 1.5, Quantity = 9, Description = "The fifth product" }

                );
        }
    }
}
