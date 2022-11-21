using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Wriststone.Common.Domain.Enums;
using Wriststone.Common.Domain.Helpers;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Data.Models.Products;
using Wriststone.Wriststone.Data.Models.Users;

namespace Wriststone.Wriststone.API.Mappers
{
    public class AutoMappers: Profile
    {
        public AutoMappers()
        {
            CreateMap<Product, ProductDTO>().ForPath(dest => dest.Ratings, 
                opt => opt.MapFrom(
                    src => src.Ratings
                        .Select(x => new RatingDTO
                        { 
                            Id = x.Id,
                            Rate = x.Rate,
                            Message = x.Message,
                            Created = x.Created,
                            Updated = x.Updated
                        })
                    ));

            CreateMap<Product, ProductListDTO>();

            CreateMap<Order, OrderDTO>().ForPath(dest => dest.OrderDetails, 
                opt => opt.MapFrom(
                    src => src.OrderDetails
                        .Select(x => new OrderDetailsDTO {Id = x.Id})
                ));

            CreateMap<OrderDetails, OrderDetailsDTO>();
            CreateMap<Rating, RatingDTO>();
        }
    }
}
