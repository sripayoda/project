using FootHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FootHub.Services.ProductDetailsServices
{
    public class ProductServices : IProduct
    {
        private FootHubContext _context;

        public ProductServices(FootHubContext context)
        {
            _context = context;
        }

        public async Task<List<ProductTable>> GetProducts()
        {
            List<ProductTable> products = await _context.ProductTables.ToListAsync();
            return products;
        }
    }
}
