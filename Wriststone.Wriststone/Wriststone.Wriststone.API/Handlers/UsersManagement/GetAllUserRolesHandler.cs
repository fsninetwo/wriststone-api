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
    public class GetAllUserRolesRequest : IRequest<IList<string>> { }

    public class GetAllUserRolesHandler : IRequestHandler<GetAllUserRolesRequest, IList<string>>
    {
        private readonly IUserManagementService _userManagementService;

        public GetAllUserRolesHandler(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public async Task<IList<string>> Handle(GetAllUserRolesRequest request, CancellationToken cancellationToken)
        {
            var userRoles = await _userManagementService.GetAllUserRolesAsync();

            return userRoles;
        }
    }
}
