using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.IRepositories;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.Services.Services
{
    public class PermissionsService : IPermissionsService
    {
        private readonly ITokenService _tokenService;
        private readonly IPermissionsRepository _permissionsRepository;

        private readonly Dictionary<Permission, string> _permissionMap = new Dictionary<Permission, string>
        {
            { Permission.Users, "Users" }
        };

        private readonly Dictionary<AccessLevel, string> _accessLevelMap = new Dictionary<AccessLevel, string>
        {
            { AccessLevel.Read, "Read" },
            { AccessLevel.Write, "Write" },
            { AccessLevel.NoAccess, "No Access" }
        };

        public PermissionsService(ITokenService tokenService, IPermissionsRepository permissionsRepository)
        {
            _tokenService = tokenService;
            _permissionsRepository = permissionsRepository;
        }

        public async Task<bool> HasPermissionAsync(Permission permission, AccessLevel accessLevel)
        {
            var permissionString = _permissionMap[permission];
            var accessLevelString = _accessLevelMap[accessLevel];

            return await HasRolePermissionAsync(permissionString, accessLevelString);
        }

        private async Task<bool> HasRolePermissionAsync(string permissionString, string accessLevelString)
        {
            var role = _tokenService.GetUserGroup();

            var permission = (Permission)Enum.Parse(typeof(Permission), permissionString);

            var accessLevel = (AccessLevel)Enum.Parse(typeof(AccessLevel), permissionString);

            var permissions = await _permissionsRepository.GetPermissionMappingsAsync(role, permission, accessLevel);

            if (!permissions.Any())
            {
                return false;
            }

            return true;
        }
    }
}
