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
        Task<IList<UserManagementDTO>> GetAllUsersAsync();

        Task UpdateUserAsync(UserManagementDTO updateUser);
    }
}
