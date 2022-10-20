using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Exceptions;
using Wriststone.Wriststone.API.Attributes;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.API.Controllers
{
    public class PermissionsController : BaseController
    {
        private readonly IPermissionsService _permissionsService;

        public PermissionsController(IPermissionsService permissionsService)
        {
            _permissionsService = permissionsService;
        }

        [HttpGet]
        [DisableTokenValidation]
        public async Task<IActionResult> GetDefaultPermissions()
        {
            var permissions = await _permissionsService.GetDefaultPermissionsAsync();

            return Ok(permissions);
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var permissions = await _permissionsService.GetPermissionsAsync();

            return Ok(permissions);
        }
    }
}
