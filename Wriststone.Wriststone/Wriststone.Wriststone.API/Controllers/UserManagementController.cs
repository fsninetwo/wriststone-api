using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Wriststone.Common.Domain.Enums;
using Wriststone.Wriststone.API.Attributes;
using Wriststone.Wriststone.API.Handlers.UserManagement;
using Wriststone.Wriststone.Data.Models;

namespace Wriststone.Wriststone.API.Controllers
{
    [RequirePageAccess(PermissionEnum.UsersManagement)]
    public class UserManagementController : BaseController
    {
        private readonly IMediator _mediatr;

        public UserManagementController(IMediator mediatr, 
            IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsersAsync()
        {
            var users = await _mediatr.Send(new GetUsersRequest());

            return Ok(users);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UserManagementDTO userManagementDto)
        {
            await _mediatr.Send(new UpdateUserRequest(userManagementDto));

            return Ok();
        }
    }
}
