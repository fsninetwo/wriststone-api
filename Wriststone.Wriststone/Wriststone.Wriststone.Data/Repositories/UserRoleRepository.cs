using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wriststone.Data.Entities.Entities;
using Wriststone.Data.Migrations;
using Wriststone.Wriststone.Data.IRepositories;

namespace Wriststone.Wriststone.Data.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly EfCoreDbContext _dbContext;
        private readonly DbSet<UserRole> _userRoleDbSet;

        public UserRoleRepository(EfCoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _userRoleDbSet = dbContext.Set<UserRole>();
        }

        public async Task<IList<string>> GetAllUserRolesAsync()
        {
            var userRoles = await _userRoleDbSet.Select(x => x.Name).ToListAsync();

            return userRoles;
        }

        private IQueryable<UserRole> GetUser(long userId, bool asNoTracking = false)
        {
            var userRoles = _userRoleDbSet
                .AsTracking(asNoTracking ? QueryTrackingBehavior.NoTracking : QueryTrackingBehavior.TrackAll);   

            return userRoles;
        }
    }
}
