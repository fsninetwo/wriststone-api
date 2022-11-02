using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.API.Handlers.UserManagement
{
    public class GetUsersRequest : IRequest<IList<UserManagementDTO>> { }

    public class GetUsersHandler : IRequestHandler<GetUsersRequest, IList<UserManagementDTO>>
    {
        private readonly IUserManagementService _userManagementService;

        public GetUsersHandler(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public async Task<IList<UserManagementDTO>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _userManagementService.GetAllUsersAsync();

            return users;
        }
    }
}
