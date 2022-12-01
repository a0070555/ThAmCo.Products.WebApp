using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThAmCo.Products.WebApp.Models;
using ThAmCo.Products.WebApp.Services;

namespace ThAmCo.Products.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IProductsRepository _productsRepository;

        public ProductsController(ILogger<ProductsController> logger, IProductsRepository productsRepository)
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }


        // GET: ProductsController
        public async Task<IActionResult> Index([FromQuery] string? subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Product> products = null;
            try
            {
                products = await _productsRepository.GetProductsAsync(subject);
            }
            catch
            {
                _logger.LogWarning("Exception occurred using Products service.");
                products = Array.Empty<Product>();
            }
            return View(products.ToList());
        }

        // GET: ProductsController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var product = await _productsRepository.GetProductAsync(id.Value);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            catch
            {
                _logger.LogWarning("Exception occurred using Products service.");
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }
    }
}
