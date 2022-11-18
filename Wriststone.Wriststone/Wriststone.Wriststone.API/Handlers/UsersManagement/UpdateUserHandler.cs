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
    public class UpdateUserRequest : IRequest
    {
        public UpdateUserRequest(UsersManagementEditDTO usersManagementDto)
        {
            UsersManagementDto = usersManagementDto;
        }

        public UsersManagementEditDTO UsersManagementDto { get; }
    }

    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest>
    {
        private readonly IUserManagementService _userManagementService;

        public UpdateUserHandler(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public async Task<Unit> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
           await _userManagementService.UpdateUserAsync(request.UsersManagementDto);

           return Unit.Value;
        }
    }
}
