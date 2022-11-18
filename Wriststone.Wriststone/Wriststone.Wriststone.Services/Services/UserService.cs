using System;
using System.Collections.Generic;
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

        public async Task AddUserAsync(UserCreateDTO userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);

            await _userRepository.AddUser(user);
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
            var user = await _userRepository.GetUserAsync(updatedUser.Id);

            if (user is null)
            {
                throw new InternalException("User is not found");
            }

            var mergedUser = UserHelper.MergeUpdatedData(updatedUser, user);
            
            await _userRepository.UpdateUser(mergedUser);

            _logger.LogDebug("Current user is updated");
            
        }
    }
}
