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
    public class GetUsersRequest : IRequest<IList<UsersManagementDTO>> { }

    public class GetUsersHandler : IRequestHandler<GetUsersRequest, IList<UsersManagementDTO>>
    {
        private readonly IUserManagementService _userManagementService;

        public GetUsersHandler(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public async Task<IList<UsersManagementDTO>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _userManagementService.GetAllUsersAsync();

            return users;
        }
    }
}
