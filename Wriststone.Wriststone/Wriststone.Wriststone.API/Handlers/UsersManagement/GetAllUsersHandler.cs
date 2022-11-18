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
    public class GetAllUsersRequest : IRequest<IList<UsersManagementDTO>> { }

    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, IList<UsersManagementDTO>>
    {
        private readonly IUserManagementService _userManagementService;

        public GetAllUsersHandler(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public async Task<IList<UsersManagementDTO>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _userManagementService.GetAllUsersAsync();

            return users;
        }
    }
}
