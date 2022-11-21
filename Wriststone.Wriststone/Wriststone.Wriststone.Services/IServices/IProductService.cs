using System.Collections.Generic;
using System.Threading.Tasks;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Data.Models.Products;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductAsync(long id);

        Task<IList<ProductListDTO>> GetProductsAsync(string searchText);

        Task<IList<ProductListDTO>> GetProductsAsync(List<long> orderDetailsIds);

        Task<IList<ProductListDTO>> GetAllProductsAsync();
    }
}
