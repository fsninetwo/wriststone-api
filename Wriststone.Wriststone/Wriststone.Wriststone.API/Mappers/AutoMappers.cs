using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Wriststone.Common.Domain.Enums;
using Wriststone.Common.Domain.Helpers;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Data.Models.Users;

namespace Wriststone.Wriststone.API.Mappers
{
    public class AutoMappers: Profile
    {
        public AutoMappers()
        {
            CreateMap<UserCreateDTO, User>()
                .ForMember(x => x.UserRole, opt => opt.Ignore())
                .ForMember(d => d.UserRoleId, 
                op => op.MapFrom(s => EnumHelper<UserRoleEnum>.ConvertToLong(s.UserRole)));

            CreateMap<User, UserDTO>().ForMember(d => d.UserRole, 
                op => op.MapFrom(s => EnumHelper<UserRoleEnum>.ConvertToString(s.UserRoleId)));

            CreateMap<User, UsersManagementDTO>().ForMember(d => d.UserRole, 
                op => op.MapFrom(s => EnumHelper<UserRoleEnum>.ConvertToString(s.UserRoleId)));

            CreateMap<User, UsersManagementEditDTO>().ForMember(d => d.UserRole, 
                op => op.MapFrom(s => EnumHelper<UserRoleEnum>.ConvertToString(s.UserRoleId)));

            CreateMap<User, UserCredentialsDTO>();

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
