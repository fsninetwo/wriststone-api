﻿using System.Threading.Tasks;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Wriststone.Data.IRepositories
{
    public interface IUserRepository
    {
        Task AddUser(User newUser);

        Task UpdateUser(User updatedUser);

        Task<User> GetUserAsync(long userId, bool asNoTracking = true);

        Task<User> GetUserByCredentialsAsync(string login, string password, bool asNoTracking = true);

        Task DeleteUser(long userId);
    }
}
