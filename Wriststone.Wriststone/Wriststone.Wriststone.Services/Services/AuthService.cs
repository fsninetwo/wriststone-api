using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.Models.Users;
using Wriststone.Wriststone.Services.Helpers;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;
        private readonly JwtHelper _jwtHelper;

        public AuthService(IUserService userService, IMapper mapper, ILogger<AuthService> logger, JwtHelper jwtHelper)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
            _jwtHelper = jwtHelper;
        }

        public async Task<UserAuthResponseDTO> Authorize(UserCredentialsDTO userCredentialsDto)
        {
            var user = await _userService.GetUserByCredentialsAsync(userCredentialsDto.Login, userCredentialsDto.Password);

            if (user is null)
            {
                return new UserAuthResponseDTO
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "Login or password is invalid.",
                    Token = null
                };
            }

            var token = _jwtHelper.GenerateToken(user);

            return new UserAuthResponseDTO
            {
                IsAuthSuccessful = true,
                Token = token
            };
        }

        public async Task Register(UserCreateDTO userCreateDto)
        {
            await _userService.AddUser(userCreateDto);
        }
    }
}
