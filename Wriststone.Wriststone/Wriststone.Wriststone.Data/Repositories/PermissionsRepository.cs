using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;
using Wriststone.Data.Migrations;
using Wriststone.Wriststone.Data.IRepositories;

namespace Wriststone.Wriststone.Data.Repositories
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly EfCoreDbContext _dbContext;
        private readonly DbSet<PermissionMapping> _permissionMappingsDbSet;

        public PermissionsRepository(EfCoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _permissionMappingsDbSet = dbContext.Set<PermissionMapping>();
        }

        public async Task<IReadOnlyList<PermissionMapping>> GetPermissionMappingsAsync(
            UserGroup userGroup, Permission permission, AccessLevel accessLevel)
        {
            var permissionMappings = 
                await GetPermissionMappings(userGroup, permission, accessLevel).ToListAsync();

            return permissionMappings;
        }

        private IQueryable<PermissionMapping> GetPermissionMappings(
            UserGroup userGroup, Permission permission, AccessLevel accessLevel, bool asNoTracking = false)
        {
            var permissionMappings = _permissionMappingsDbSet
                .Where(x => x.UserGroup == userGroup 
                         && x.Permission == permission 
                         && x.AccessLevel == accessLevel)
                .AsTracking(asNoTracking ? QueryTrackingBehavior.NoTracking : QueryTrackingBehavior.TrackAll);   

            return permissionMappings;
        }

    }
}
