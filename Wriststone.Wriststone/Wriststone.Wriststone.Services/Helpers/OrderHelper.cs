using System;
using System.Collections.Generic;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.Models;

namespace Wriststone.Wriststone.Services.Helpers
{
    public static class OrderHelper
    {
        public static Order ConvertOrderDTOtoRating(OrderCreateDTO order, long userId)
        {
            var newOrderDetailsList = new List<OrderDetails>();

            foreach (var orderDetails in order.OrderDetails)
            {
                var newOrderDetails = new OrderDetails
                {
                    ProductId = orderDetails.ProductId
                };

                newOrderDetailsList.Add(newOrderDetails);
            }

            var created = DateTime.Now;

            var newOrder = new Order
            {
                Payment = order.Payment,
                Guid = Guid.NewGuid(),
                IsCompleted = false,
                PurchaseDate = created,
                OrderDetails = newOrderDetailsList,
                UserId = userId
            };

            return newOrder;
        }

        public static Order ConvertOrderDTOtoRating(OrderUpdateDTO order)
        {
            var updateOrderDetailsList = new List<OrderDetails>();

            foreach (var orderDetails in order.OrderDetails)
            {
                var newOrderDetails = new OrderDetails
                {
                    Id = orderDetails.Id,
                    ProductId = orderDetails.ProductId,
                    OrderId = orderDetails.OrderId,
                };

                updateOrderDetailsList.Add(newOrderDetails);
            }


            var updateOrder = new Order
            {
                Id = order.Id,
                Payment = order.Payment,
                Guid = order.Guid,
                IsCompleted = order.IsCompleted,
                PurchaseDate = order.PurchaseDate,
                UserId = order.UserId,
                OrderDetails = updateOrderDetailsList
            };

            return updateOrder;
        }
    }
}
