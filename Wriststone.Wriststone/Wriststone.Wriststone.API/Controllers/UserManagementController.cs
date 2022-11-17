using Microsoft.AspNetCore.Mvc;
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

namespace Wriststone.Wriststone.API.Controllers
{
    [RequirePageAccess(PermissionEnum.UsersManagement)]
    public class UsersManagementController : BaseController
    {
        private readonly IMediator _mediatr;

        public UsersManagementController(IMediator mediatr, 
            IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsersAsync()
        {
            var users = await _mediatr.Send(new GetAllUsersRequest());

            return Ok(users);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUserRolesAsync()
        {
            var userRoles = await _mediatr.Send(new GetAllUserRolesRequest());

            return Ok(userRoles);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetUserAsync(long id)
        {
            var user = await _mediatr.Send(new GetUserRequest(id));

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UsersManagementEditDTO usersManagementDto)
        {
            await _mediatr.Send(new UpdateUserRequest(usersManagementDto));

            return Ok();
        }
    }
}
