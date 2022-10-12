using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface ITokenService
    {
        UserGroup GetUserGroup(string token);
    }
}
