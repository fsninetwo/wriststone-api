using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Exceptions;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.Services.Services
{
    public class TokenService : ITokenService
    {
        public UserGroup GetUserGroup(string token)
        {
            var decodedToken = ParseToken(token);

            var (key, value) = decodedToken.Payload.FirstOrDefault(x => x.Key.Equals(ClaimTypes.Role));

            if (key is null || value is null)
            {
                throw new InternalException("Unable to get role");
            }

            return (UserGroup)Enum.Parse(typeof(UserGroup), value.ToString());
        }

        private static JwtSecurityToken ParseToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                return (JwtSecurityToken) handler.ReadToken(token);
            }
            catch
            {
                throw new InternalException("Failed to parse security token");
            }
        }
    }
}
