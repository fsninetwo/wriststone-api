using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Wriststone.Data.Models;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface IUserManagementService
    {
        Task<IList<UsersManagementDTO>> GetAllUsersAsync();

        Task<IList<string>> GetAllUserRolesAsync();

        Task UpdateUserAsync(UsersManagementEditDTO updateUsers);

        Task DeleteUserAsync(long userId);

        Task<UsersManagementEditDTO> GetUserAsync(long userId);
    }
}
