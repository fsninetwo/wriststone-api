﻿using Microsoft.AspNetCore.Http;
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
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id}")]
        [DisableTokenValidation]
        public async Task<IActionResult> GetUser(long id)
        {
            var user = await _userService.GetUserAsync(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser([FromBody] UserUpdateDTO userUpdateDTO)
        {
            await _userService.UpdateUserAsync(userUpdateDTO);

            return Ok();
        }
    }
}
