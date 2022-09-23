using System.Threading.Tasks;
using Wriststone.Wriststone.Data.Models;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface IUserService
    {
        Task UpdateUserAsync(UserUpdateDTO updateUser);

        Task<UserDTO> GetUserAsync(long id);

        Task<UserCredentialsResult> GetUserByCredentialsAsync(string login, string password);
    }
}
