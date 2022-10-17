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

        public async Task<IList<PermissionMapping>> GetPermissionsAsync(string userRole)
        {
            var permissionMappings = 
                await GetPermissionMappings(userRole).ToListAsync();

            return null;
        }

        public async Task<IList<PermissionMapping>> GetPermissionsAsync(
            string userRole, string permission, string accessLevel)
        {
            var permissionMappings = 
                await GetPermissionMappings(userRole, permission, accessLevel).ToListAsync();

            return permissionMappings;
        }

        private IQueryable<PermissionMapping> GetPermissionMappings(
            string userRole, string permission, string accessLevel, bool asNoTracking = false)
        {
            var permissionMappings = GetPermissionMappings(userRole)
                .Include(x => x.AccessLevel)
                .Include(x => x.Permission)
                .Where(x => x.AccessLevel.Name == accessLevel)
                .Where(x => x.Permission.Name == permission)
                .AsTracking(asNoTracking ? QueryTrackingBehavior.NoTracking : QueryTrackingBehavior.TrackAll);   

            return permissionMappings;
        }

        private IQueryable<PermissionMapping> GetPermissionMappings(string userRole, bool asNoTracking = false)
        {
            var permissionMappings = _permissionMappingsDbSet
                .Include(x => x.UserRole)
                .Where(x => x.UserRole.Name == userRole)
                .AsTracking(asNoTracking ? QueryTrackingBehavior.NoTracking : QueryTrackingBehavior.TrackAll);   

            return permissionMappings;
        }
    }
}
