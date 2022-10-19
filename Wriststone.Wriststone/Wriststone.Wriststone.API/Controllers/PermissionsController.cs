using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Wriststone.API.Attributes;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.API.Controllers
{
    [DisableTokenValidation]
    public class PermissionsController : BaseController
    {
        private readonly IPermissionsService _permissionsService;

        public PermissionsController(IPermissionsService permissionsService)
        {
            _permissionsService = permissionsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDefaultPermissionsAsync()
        {
            var permissions = await _permissionsService.GetDefaultPermissions();

            return Ok(permissions);
        }
    }
}
