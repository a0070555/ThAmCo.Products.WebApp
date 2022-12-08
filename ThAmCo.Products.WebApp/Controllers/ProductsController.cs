using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Products.WebApp.Models;
using ThAmCo.Products.WebApp.Services;

namespace ThAmCo.Products.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IProductsRepository _productsRepository;
        private readonly ProductsContext _context;

        public ProductsController(ILogger<ProductsController> logger, IProductsRepository productsRepository, ProductsContext context)
        {
            _logger = logger;
            _productsRepository = productsRepository;
            _context = context;
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

        //public IActionResult Create()
        //{
        //    return View();
        //}

        ////POST: Products/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ProductId,ProductName,Quantity,Price,Description")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(product);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Quantity,Price,Description")] Product product)
        //{
        //    if (id != product.ProductId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var productDetails = await _context.Products.FindAsync(id);
        //            if (productDetails == null)
        //            {
        //                return NotFound();
        //            }

        //            productDetails.ProductName = product.ProductName;
        //            productDetails.Quantity = product.Quantity;
        //            productDetails.Price = product.Price;
        //            productDetails.Description = product.Description;

        //            await _context.SaveChangesAsync(); 
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.ProductId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        //// GET: Products/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .FirstOrDefaultAsync(m => m.ProductId == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(p => p.ProductId == id);
        //}
    }
}
