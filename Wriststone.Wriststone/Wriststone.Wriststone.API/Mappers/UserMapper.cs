using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Wriststone.Common.Domain.Enums;
using Wriststone.Common.Domain.Helpers;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Data.Models.Users;

namespace Wriststone.Wriststone.API.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
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
        }
    }
}
