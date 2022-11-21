using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Wriststone.Common.Domain.Exceptions;
using Wriststone.Common.Domain.Helpers;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.API.Mappers;
using Wriststone.Wriststone.Data.IRepositories;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Data.Models.Products;
using Wriststone.Wriststone.Services.IServices;
using Wriststone.Wriststone.Services.Services;
using Xunit;

namespace Wriststone.Wriststone.Services.Tests
{
    public class OrderServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IProductService> _mockProductService;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly IOrderService _orderService;

        public OrderServiceTests()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new API.Mappers.AutoMappers()); });
            _mapper = mappingConfig.CreateMapper();

            _mockUserService = new Mock<IUserService>();
            _mockProductService = new Mock<IProductService>();
            _mockOrderRepository = new Mock<IOrderRepository>();
            _orderService = new OrderService(_mapper, _mockOrderRepository.Object, _mockUserService.Object, _mockProductService.Object);
        }

        #region TestData

        private readonly List<long> _validOrderDetailIds = new List<long>() {1, 2, 3, 4};

        private readonly User _validUser = new User() { Id = 1, Login = "Test" };
        
        private readonly List<Order> _validOrders = new List<Order>()
        {
            new Order()
            {
                Id = 1,
                UserId = 1,
                OrderDetails = new List<OrderDetails>()
                {
                    new OrderDetails() { Id = 1, ProductId = 1 },
                    new OrderDetails() { Id = 2, ProductId = 2 }
                }
            },
            new Order()
            {
                Id = 2,
                UserId = 1,
                OrderDetails = new List<OrderDetails>()
                {
                    new OrderDetails() { Id = 1, ProductId = 1 },
                    new OrderDetails() { Id = 3, ProductId = 3 },
                    new OrderDetails() { Id = 4, ProductId = 4 }
                }
            }
        };

        private readonly List<OrderDTO> _validOrdersDTO = new List<OrderDTO>()
        {
            new OrderDTO()
            {
                Id = 1,
                UserId = 1,
                OrderDetails = new List<OrderDetailsDTO>()
                {
                    new OrderDetailsDTO() { Id = 1, Product = "Test 1" },
                    new OrderDetailsDTO() { Id = 2, Product = "Test 2" }
                }
            },
            new OrderDTO()
            {
                Id = 2,
                UserId = 1,
                OrderDetails = new List<OrderDetailsDTO>()
                {
                    new OrderDetailsDTO() { Id = 1, Product = "Test 1" },
                    new OrderDetailsDTO() { Id = 3, Product = "Test 3" },
                    new OrderDetailsDTO() { Id = 4, Product = "Test 4" }
                }
            }
        };

        private readonly List<ProductListDTO> _validProducts = new List<ProductListDTO>()
        {
            new ProductListDTO()
            {
                Id = 1,
                Name = "Test 1",

            },
            new ProductListDTO()
            {
                Id = 2,
                Name = "Test 2",
            },
            new ProductListDTO()
            {
                Id = 3,
                Name = "Test 3",
            },
            new ProductListDTO()
            {
                Id = 4,
                Name = "Test 4",
            }
        };

        #endregion

        [Fact]
        public async Task GetOrdersAsync_NoProjects_ShouldThrowException()
        {
            _mockOrderRepository.Setup(x => x.GetOrdersAsync(1, It.IsAny<bool>()))
                .ReturnsAsync(() => _validOrders);

            _mockProductService.Setup(x => x.GetProductsAsync(It.IsAny<List<long>>()))
                .ReturnsAsync(() => null);

            await Assert.ThrowsAsync<InternalException>(() => 
                _orderService.GetOrdersAsync(1));
        }

        [Fact]
        public async Task GetOrdersAsync_ShouldReturnValidOrders()
        {
            var userId = 1;

            _mockOrderRepository.Setup(x => x.GetOrdersAsync(userId, It.IsAny<bool>()))
                .ReturnsAsync(() => _validOrders);

            _mockProductService.Setup(x => x.GetProductsAsync(_validOrderDetailIds))
                .ReturnsAsync(() => _validProducts);

            var result = await _orderService.GetOrdersAsync(userId);

            Assert.True(result.JsonCompare(_validOrdersDTO));
        }
    }
}
