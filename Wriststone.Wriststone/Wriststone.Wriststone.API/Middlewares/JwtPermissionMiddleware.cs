using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Wriststone.Common.Domain.Exceptions;
using Wriststone.Wriststone.API.Helpers;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.API.Middlewares
{
    public class JwtPermissionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public JwtPermissionMiddleware(
            RequestDelegate next, IConfiguration configuration, ILogger<JwtPermissionMiddleware> logger)
        {
            _next = next;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, ITokenService tokenService)
        {
            if (VerificationHelper.ShouldApplyTokenVerification(context))
            {
                var authorizationToken = tokenService.TokenString;

                if (authorizationToken is null)
                {
                    throw new UnauthorizedException("Token is empty or invalid");
                }
            }

            await _next(context);
        }
    }
}
