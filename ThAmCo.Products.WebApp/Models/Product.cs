using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Products.WebApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        public string? Description { get; set; }
    }

}
