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
        Task<IReadOnlyList<PermissionMapping>> GetPermissionMappingsAsync(
            UserGroup userGroup, Permission permission, AccessLevel accessLevel);
    }
}
