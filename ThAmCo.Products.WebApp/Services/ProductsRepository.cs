using ThAmCo.Products.WebApp.Models;
using System.Net;

namespace ThAmCo.Products.WebApp.Services
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly HttpClient _client;
        public ProductsRepository(HttpClient client)
        {
            client.BaseAddress = new System.Uri("http://localhost:7178/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var response = await _client.GetAsync("api/products/" + id);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                response.EnsureSuccessStatusCode();
                var product = await response.Content.ReadAsAsync<Product>();
                return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(string subject)
        {
            var uri = "api/products";
            if (subject != null)
            {
                uri = uri + "&subject=" + subject;
            }
            var response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<IEnumerable<Product>>();
            return products;
        }
    }
}
