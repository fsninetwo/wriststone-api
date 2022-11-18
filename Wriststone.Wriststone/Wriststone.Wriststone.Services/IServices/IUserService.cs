using System.Collections.Generic;
using System.Threading.Tasks;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Data.Models.Users;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByCredentialsAsync(string login, string password);

        Task UpdateUserAsync(UserUpdateDTO updateUser);

        Task<UserDTO> GetUserAsync(long id);

        Task AddUserAsync(UserCreateDTO userCreateDto);
    }
}
