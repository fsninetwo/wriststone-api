using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Wriststone.Data.Models.Users;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface IAuthService
    {
        Task<UserAuthResponseDTO> Authorize(UserCredentialsDTO userCredentialsDto);

        Task Register(UserCreateDTO userCreateDto);
    }
}
