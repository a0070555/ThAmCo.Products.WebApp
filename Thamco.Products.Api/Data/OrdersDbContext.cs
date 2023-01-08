using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thamco.Products.Api.Models;

namespace ThAmCo.Products.Api.Data
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
        {
        }

        private readonly IHostEnvironment _hostEnv;

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options,
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

            builder.HasDefaultSchema("thamco.products.api");


            builder.Entity<Order>()
                   .HasData(
                        new Order { OrderId = 1, ProductId = 1 },
                        new Order { OrderId = 2, ProductId = 2 }
                    );
        }
    }
}
