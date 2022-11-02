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
            var users = await _mediatr.Send(new GetUsersRequest());

            return Ok(users);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UsersManagementDTO usersManagementDto)
        {
            await _mediatr.Send(new UpdateUserRequest(usersManagementDto));

            return Ok();
        }
    }
}
