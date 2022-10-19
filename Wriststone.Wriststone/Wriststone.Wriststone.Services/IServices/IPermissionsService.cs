using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.Models;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface IPermissionsService
    {
        Task<bool> HasPermissionAsync(PermissionEnum permissionEnum, AccessLevelEnum accessLevelEnum);

        Task<IList<PermissionDTO>> GetDefaultPermissions();

        Task<IList<PermissionDTO>> GetPermissions();
    }
}
