using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Wriststone.API.Attributes;

namespace Wriststone.Wriststone.API.Helpers
{
    public static class TokenVerificationHelper
    {
        public static bool ShouldApplyTokenVerification(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var attribute = endpoint?.Metadata.GetMetadata<DisableTokenValidationAttribute>();

            return attribute == null;
        }
    }
}
