using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Wriststone.Common.Domain.Exceptions;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.IRepositories;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Data.Models.Users;
using Wriststone.Wriststone.Services.Helpers;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly JwtHelper _jwtService;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger, JwtHelper jwtService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
            _jwtService = jwtService;
        }

        public async Task<UserAuthResponseDTO> Authorize(UserCredentialsDTO userCredentialsDto)
        {
            var user = await GetUserByCredentialsAsync(userCredentialsDto.Login, userCredentialsDto.Password);

            if (user is null)
            {
                return new UserAuthResponseDTO
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "Login or password is invalid.",
                    Token = null
                };
            }

            var token = _jwtService.GenerateToken(user);

            return new UserAuthResponseDTO
            {
                IsAuthSuccessful = true,
                Token = token
            };
        }

        public async Task Register(UserCreateDTO userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            await _userRepository.AddUser(user);
        }

        public async Task<UserDTO> GetUserAsync(long id)
        {
            var user = await _userRepository.GetUserAsync(id);

            var userModel = _mapper.Map<UserDTO>(user);
            _logger.LogDebug("User {0} is selected", userModel.Login);

            return userModel;
        }

        public async Task<UserDTO> GetUserByCredentialsAsync(string login, string password)
        {
            var user = await _userRepository.GetUserByCredentialsAsync(login, password);

            if (user is null) return null;

            var userModel = _mapper.Map<UserDTO>(user);

            _logger.LogDebug("User {0} credentials is selected", userModel.Login);

            return userModel;
        }

        public async Task UpdateUserAsync(UserUpdateDTO updatedUser)
        {
            try
            {
                var user = await _userRepository.GetUserAsync(updatedUser.Id);

                if (user is null)
                {
                    throw new InternalException("User is not found");
                }

                var mergedUser = UserHelper.MergeUpdatedData(updatedUser, user);

                await _userRepository.UpdateUser(mergedUser);

                _logger.LogDebug("Current user is updated");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error," + ex.Message);
            }
        }
    }
}
