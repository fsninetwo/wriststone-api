using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.IRepositories;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.Services.Services
{
    public class PermissionsService : IPermissionsService
    {
        private readonly ITokenService _tokenService;
        private readonly IPermissionsRepository _permissionsRepository;

        private readonly Dictionary<PermissionEnum, string> _permissionMap = new Dictionary<PermissionEnum, string>
        {
            { PermissionEnum.UserManagement, "User Management" }
        };

        private readonly Dictionary<AccessLevelEnum, string> _accessLevelMap = new Dictionary<AccessLevelEnum, string>
        {
            { AccessLevelEnum.Read, "Read" },
            { AccessLevelEnum.Write, "Write" },
            { AccessLevelEnum.NoAccess, "No Access" }
        };

        public PermissionsService(ITokenService tokenService, IPermissionsRepository permissionsRepository)
        {
            _tokenService = tokenService;
            _permissionsRepository = permissionsRepository;
        }

        public async Task<IList<PermissionDTO>> GetDefaultPermissions()
        {
            var permissionMappings = await _permissionsRepository.GetPermissionsByUserRoleAsync();

            return permissionMappings;
        }

        public async Task<bool> HasPermissionAsync(PermissionEnum permissionEnum, AccessLevelEnum accessLevelEnum)
        {
            var permissionString = _permissionMap[permissionEnum];
            var accessLevelString = _accessLevelMap[accessLevelEnum];

            return await HasRolePermissionAsync(permissionString, accessLevelString);
        }

        private async Task<bool> HasRolePermissionAsync(string permissionString, string accessLevelString)
        {
            var roleString = _tokenService.GetUserGroup();

            var permissions = await _permissionsRepository.GetPermissionsAsync(roleString, permissionString, accessLevelString);

            return permissions.Any();
        }
    }
}
