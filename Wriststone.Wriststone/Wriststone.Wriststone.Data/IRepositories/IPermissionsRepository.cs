using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Wriststone.Data.IRepositories
{
    public interface IPermissionsRepository
    {
        Task<IList<PermissionMapping>> GetPermissionsAsync(string userRole);

        Task<IList<PermissionMapping>> GetPermissionsAsync(
            string userRoleEnum, string permissionEnum, string accessLevelEnum);   
    }
}
