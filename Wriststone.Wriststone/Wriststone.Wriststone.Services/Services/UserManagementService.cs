using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Wriststone.Common.Domain.Exceptions;
using Wriststone.Wriststone.Data.IRepositories;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Services.Helpers;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.Services.Services
{
    public class UserManagementService: IUserManagementService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserManagementService(
            IUserRepository userRepository, IUserRoleRepository userRoleRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IList<UsersManagementDTO>> GetAllUsersAsync()
        {
            var user = await _userRepository.GetAllUsersAsync();

            var userModel = _mapper.Map<IList<UsersManagementDTO>>(user);

            return userModel;
        }

        public async Task<IList<string>> GetAllUserRolesAsync()
        {
            var userRoles = await _userRoleRepository.GetAllUserRolesAsync();

            return userRoles;
        }

        public async Task UpdateUserAsync(UsersManagementEditDTO updatedUser)
        {
            var user = await _userRepository.GetUserAsync(updatedUser.Id);

            if (user is null)
            {
                throw new InternalException("User is not found");
            }

            var mergedUser = UserHelper.MergeUpdatedData(updatedUser, user);
            
            await _userRepository.UpdateUser(mergedUser);

            _logger.LogDebug($"User {updatedUser.Id} is updated");
        }

        public async Task RemoveUserAsync(long userId)
        {
            await _userRepository.DeleteUser(userId);

            _logger.LogDebug($"User is deleted");
        }

        public async Task<UsersManagementEditDTO> GetUserAsync(long userId)
        {
            var user = await _userRepository.GetUserAsync(userId);

            if (user is null)
            {
                throw new InternalException("User is not found");
            }
            if (user is null) return null;

            var userModel = _mapper.Map<UsersManagementEditDTO>(user);

            _logger.LogDebug("User {0} credentials is selected", userModel.Login);

            return userModel;
        }
    }
}
