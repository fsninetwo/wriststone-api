using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Data.Models.Users;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.API.Handlers.UsersManagement
{
    public class AddUserRequest : IRequest
    {
        public AddUserRequest(UserCreateDTO userCreateDTO)
        {
            UserCreateDTO = userCreateDTO;
        }

        public UserCreateDTO UserCreateDTO { get; }
    }

    public class AddUserHandler : IRequestHandler<AddUserRequest>
    {
        private readonly IUserService _userService;

        public AddUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Unit> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
           await _userService.AddUserAsync(request.UserCreateDTO);

           return Unit.Value;
        }
    }
}
