﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Wriststone.Common.Domain.Enums;
using Wriststone.Wriststone.API.Attributes;
using Wriststone.Wriststone.API.Handlers.UsersManagement;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Data.Models.Users;

namespace Wriststone.Wriststone.API.Controllers
{
    [RequirePageAccess(PermissionEnum.UserManagement)]
    public class UsersManagementController : BaseController
    {
        private readonly IMediator _mediatr;

        public UsersManagementController(IMediator mediatr, 
            IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _mediatr.Send(new GetAllUsersRequest());

            return Ok(users);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUserRoles()
        {
            var userRoles = await _mediatr.Send(new GetAllUserRolesRequest());

            return Ok(userRoles);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetUser(long id)
        {
            var user = await _mediatr.Send(new GetUserRequest(id));

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] UserCreateDTO usersCreateDto)
        {
            var users = await _mediatr.Send(new AddUserRequest(usersCreateDto));

            return Ok(users);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] UsersManagementEditDTO usersManagementDto)
        {
            await _mediatr.Send(new UpdateUserRequest(usersManagementDto));

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoveUser(long id)
        {
            await _mediatr.Send(new RemoveUserRequest(id));

            return Ok();
        }
    }
}
