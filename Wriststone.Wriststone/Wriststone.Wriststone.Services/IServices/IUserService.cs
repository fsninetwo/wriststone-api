using System.Threading.Tasks;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Data.Models.Users;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface IUserService
    {
        Task UpdateUserAsync(UserUpdateDTO updateUser);

        Task<UserDTO> GetUserAsync(long id);
        
        Task<UserAuthResponseDTO> Authorize(UserCredentialsDTO userCredentialsDto);

        Task Register(UserCreateDTO userCreateDto);
    }
}
