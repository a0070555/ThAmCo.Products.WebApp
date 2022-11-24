using System;
using ThAmCo.Products.WebApp.Models;

namespace ThAmCo.Products.WebApp.Services
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(string subject);

        Task<Product> GetProductAsync(int id);
    }
}
