using System.Collections.Generic;
using System.Threading.Tasks;
using Wriststone.Wriststone.Data.Models;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface IOrderService
    {
        Task AddOrderAsync(OrderCreateDTO newOrder);

        Task UpdateOrderAsync(OrderUpdateDTO newOrder);

        Task<OrderDTO> GetOrderAsync(long id);

        Task<List<OrderDTO>> GetOrdersAsync(long userId);
    }
}
