using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.API.Handlers.UsersManagement
{
    public class GetUserRequest : IRequest<UsersManagementEditDTO>
    {
        public GetUserRequest(long userId)
        {
            UserId = userId;
        }

        public long UserId { get; }
    }

    public class GetUserHandler : IRequestHandler<GetUserRequest, UsersManagementEditDTO>
    {
        private readonly IUserManagementService _userManagementService;

        public GetUserHandler(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public async Task<UsersManagementEditDTO> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManagementService.GetUserAsync(request.UserId);

            return user;
        }
    }
}
