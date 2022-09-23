using System.Collections.Generic;
using System.Threading.Tasks;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Wriststone.Data.IRepositories
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order newOrder);

        Task UpdateOrderAsync(Order updatedOrder);

        Task<Order> GetOrderAsync(long OrderId, bool asNoTracking = true);

        Task<List<Order>> GetOrdersAsync(long userId, bool asNoTracking = true);

        Task DeleteOrderAsync(long OrderId);
    }
}
