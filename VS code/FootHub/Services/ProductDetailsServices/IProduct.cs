using FootHub.Models;

namespace FootHub.Services.ProductDetailsServices
{
    public interface IProduct
    {
        Task<List<ProductTable>> GetProducts(); 
    }
}
