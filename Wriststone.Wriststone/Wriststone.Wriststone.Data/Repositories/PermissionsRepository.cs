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
using Wriststone.Wriststone.Data.Models;

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

        public async Task<IList<PermissionDTO>> GetPermissionsByUserRoleAsync(
            string userRole, bool asNoTracking = true)
        {
            var permissionMappings = 
                await GetPermissionMappings(userRole, asNoTracking)
                    .Select(x => new PermissionDTO
                    {
                        Permission = x.AccessLevel.Name,
                        AccessLevel = x.Permission.Name
                    }).ToListAsync();

            return permissionMappings;
        }

        public async Task<IList<PermissionDTO>> GetPermissionsAsync(
            string userRole, string permission, string accessLevel, bool asNoTracking = true)
        {
            var permissionMappings = 
                await GetPermissionMappings(userRole, permission, accessLevel)
                    .Select(x => new PermissionDTO
                    {
                        Permission = x.AccessLevel.Name,
                        AccessLevel = x.Permission.Name
                    }).ToListAsync();
            
            return permissionMappings;

            throw new Exception();
        }

        private IQueryable<PermissionMapping> GetPermissionMappings(
            string userRole, string permission, string accessLevel, bool asNoTracking = false)
        {
            var permissionMappings = GetPermissionMappings(userRole)
                .Where(x => x.AccessLevel.Name == accessLevel)
                .Where(x => x.Permission.Name == permission);   

            return permissionMappings;
        }

        private IQueryable<PermissionMapping> GetPermissionMappings(string userRole, bool asNoTracking = false)
        {
            var permissionMappings = _permissionMappingsDbSet
                .Include(x => x.UserRole)
                .Include(x => x.AccessLevel)
                .Include(x => x.Permission)
                .Where(x => x.UserRole.Name == userRole)
                .AsTracking(asNoTracking ? QueryTrackingBehavior.NoTracking : QueryTrackingBehavior.TrackAll);   

            return permissionMappings;
        }
    }
}
