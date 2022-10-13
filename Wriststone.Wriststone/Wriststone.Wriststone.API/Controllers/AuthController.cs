using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Wriststone.API.Attributes;
using Wriststone.Wriststone.Data.Models.Users;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.API.Controllers
{
    [DisableTokenValidation]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService): base()
        {
            _authService = authService;
        }

        [HttpPost]  
        public async Task<IActionResult> Authorize([FromBody] UserCredentialsDTO userCredentialsDTO)
        {
            var result = await _authService.Authorize(userCredentialsDTO);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserCreateDTO userCreateDto)
        {
            await _authService.Register(userCreateDto);

            return Ok();
        }
    }
}
