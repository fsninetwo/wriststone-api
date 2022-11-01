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
    public class GetUsersRequest : IRequest<IList<UserDTO>> { }

    public class GetUsersHandler : IRequestHandler<GetUsersRequest, IList<UserDTO>>
    {
        private readonly IUserService _userService;

        public GetUsersHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IList<UserDTO>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsersAsync();

            return users;
        }
    }
}
