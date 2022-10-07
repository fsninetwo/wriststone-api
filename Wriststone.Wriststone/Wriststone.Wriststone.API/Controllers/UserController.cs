using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Wriststone.Data.Models.Users;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Authorize([FromBody] UserCredentialsDTO userCredentialsDTO)
        {
            var result = await _userService.Authorize(userCredentialsDTO);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserCreateDTO userCreateDto)
        {
            await _userService.Register(userCreateDto);

            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var user = await _userService.GetUserAsync(id);

            return Ok(user);
        }
    }
}
