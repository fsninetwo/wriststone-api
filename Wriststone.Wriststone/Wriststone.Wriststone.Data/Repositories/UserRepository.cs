using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wriststone.Common.Domain.Exceptions;
using Wriststone.Data.Entities.Entities;
using Wriststone.Data.Migrations;
using Wriststone.Wriststone.Data.IRepositories;

namespace Wriststone.Wriststone.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EfCoreDbContext _dbContext;
        private readonly DbSet<User> _userDbSet;

        public UserRepository(EfCoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _userDbSet = dbContext.Set<User>();
        }

        public async Task AddUser(User user)
        {
            _userDbSet.Add(user);

            await _dbContext.SaveChangesAsync();
        }


        public async Task DeleteUser(long id)
        {
            var user = await GetUserAsync(id);

            if (user is null)
            {
                throw new InternalException("User is not found");
            }

            _userDbSet.Remove(user);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(long userId, bool asNoTracking = true)
        {
            var user = await GetUser(userId,true).FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> GetUserByCredentialsAsync(string login, string password, bool asNoTracking = true)
        {
            var user = await GetUser(login, password, true).FirstOrDefaultAsync();
            return user;
        }

        public async Task UpdateUser(User updatedUser)
        {
            var user = await GetUserAsync(updatedUser.Id);

            if (user is null)
            {
                throw new InternalException("User is not found");
            }

            _userDbSet.Update(updatedUser);

            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<User> GetUser(long userId, bool asNoTracking = false)
        {
            var user = _userDbSet
                .Where(x => x.Id == userId)
                .AsTracking(asNoTracking ? QueryTrackingBehavior.NoTracking : QueryTrackingBehavior.TrackAll);   

            return user;
        }

        private IQueryable<User> GetUser(string login, string password, bool asNoTracking = false)
        {
            var user = _userDbSet
                .Where(x => x.Login == login && x.Password == password)
                .AsTracking(asNoTracking ? QueryTrackingBehavior.NoTracking : QueryTrackingBehavior.TrackAll);  

            return user;
        }
    }
}
