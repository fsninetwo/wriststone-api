using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.Models;

namespace Wriststone.Wriststone.Data.IRepositories
{
    public interface IPermissionsRepository
    {
        Task<IList<PermissionDTO>> GetPermissionsByUserRoleAsync(
            string userRole = nameof(UserRoleEnum.User), bool asNoTracking = true);

        Task<IList<PermissionDTO>> GetPermissionsAsync(
            string userRoleEnum, string permissionEnum, string accessLevelEnum, bool asNoTracking = true);   
    }
}
