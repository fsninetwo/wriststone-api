using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wriststone.Wriststone.Data.IRepositories
{
    public interface IUserRoleRepository
    {
        Task<IList<string>> GetAllUserRolesAsync();
    }
}
