using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Enums;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface IPermissionsService
    {
        Task<bool> HasPermissionAsync(Permission permission, AccessLevel accessLevel);
    }
}
