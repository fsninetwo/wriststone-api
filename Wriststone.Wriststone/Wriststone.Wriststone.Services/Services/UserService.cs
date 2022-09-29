using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
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

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
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

            var userModel = _mapper.Map<UserDTO>(user);

            _logger.LogDebug("User {0} credentials is selected", userModel.Login);

            return userModel;
        }

        public async Task UpdateUserAsync(UserUpdateDTO updateUser)
        {
            try
            {
                var mapUser = UserHelper.ConvertUserDTOtoUser(updateUser);

                await _userRepository.UpdateUser(mapUser);

                _logger.LogDebug("New user is added");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error," + ex.Message);
            }
        }

        public async Task<UserAuthResponseDTO> Authorize(UserCredentialsDTO userCredentialsDto)
        {
            var user = await GetUserByCredentialsAsync(userCredentialsDto.Login, userCredentialsDto.Password);
        }
    }
}
