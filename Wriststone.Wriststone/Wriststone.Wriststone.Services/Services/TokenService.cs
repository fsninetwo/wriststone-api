using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Enums;
using Wriststone.Common.Domain.Exceptions;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.Services.Services
{
    public class TokenService : ITokenService
    {
        public string TokenRaw { get; set; }

        public string TokenString { get; }

        public TokenService(IHttpContextAccessor httpContextAccessor)
        {
            var authorizationHandler = httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            if (authorizationHandler.Count > 0)
            {
                TokenRaw = authorizationHandler.ToString();
                TokenString = authorizationHandler.ToString()
                    .Replace("Bearer ", string.Empty, StringComparison.OrdinalIgnoreCase);
            }
        }

        public UserGroup GetUserGroup()
        {
            var decodedToken = ParseToken(TokenString);

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
