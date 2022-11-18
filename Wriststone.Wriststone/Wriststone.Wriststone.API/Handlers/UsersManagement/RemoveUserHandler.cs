using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.API.Handlers.UsersManagement
{
    public class RemoveUserRequest : IRequest
    {
        public RemoveUserRequest(long userId)
        {
            UserId = userId;
        }

        public long UserId { get; }
    }

    public class RemoveUserHandler : IRequestHandler<RemoveUserRequest>
    {
        private readonly IUserManagementService _userManagementService;

        public RemoveUserHandler(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public async Task<Unit> Handle(RemoveUserRequest request, CancellationToken cancellationToken)
        {
           await _userManagementService.RemoveUserAsync(request.UserId);

           return Unit.Value;
        }
    }
}
