using FootHub.Models;
using FootHub.Services.ProductDetailsServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct _context;

        public ProductController(IProduct context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductTable>>> GetProducts()
        {
            var products = await _context.GetProducts();
            return Ok(products);
        }
    }
}
