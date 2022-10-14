using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Wriststone.Common.Domain.Enums;
using Wriststone.Common.Domain.Exceptions;
using Wriststone.Wriststone.API.Helpers;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.API.Middlewares
{
    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly string[] _writeMethods =
        {
            HttpMethods.Post,
            HttpMethods.Put,
            HttpMethods.Patch,
            HttpMethods.Delete
        };

        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public PermissionMiddleware(
            RequestDelegate next, IConfiguration configuration, ILogger<JwtPermissionMiddleware> logger)
        {
            _next = next;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, ITokenService tokenService, 
            IPermissionsService permissionsService)
        {
            var attribute = VerificationHelper.GetRequirePageAccess(context);
            if (attribute != null)
            {
                var authorizationToken = tokenService.TokenString;

                if (authorizationToken is null)
                {
                    throw new UnauthorizedException("Token is empty or invalid");
                }

                var permission = attribute.Permission;
                var accessLevel = attribute.AccessLevel ?? GetAccessLevelFromRequest(context);

                var hasAccess = await permissionsService.HasPermissionAsync(permission, accessLevel);

                if (!hasAccess)
                {
                    throw new UnauthorizedException("You don't have access to this endpoint");
                }
            }

            await _next(context);
        }

        private AccessLevel GetAccessLevelFromRequest(HttpContext context)
        {
            var method = context.Request.Method;

            return _writeMethods.Contains(method)
                ? AccessLevel.Write
                : AccessLevel.Read;
        }
    }
}

