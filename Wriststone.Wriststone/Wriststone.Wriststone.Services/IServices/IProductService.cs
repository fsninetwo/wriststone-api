using System.Collections.Generic;
using System.Threading.Tasks;
using Wriststone.Wriststone.Data.Models;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductAsync(long id);

        Task<List<ProductDTO>> GetProductsAsync(string searchText);

        Task<List<ProductDTO>> GetProductsAsync(List<long> orderDetailsIds);

        Task<List<ProductDTO>> GetAllProductsAsync();
    }
}
