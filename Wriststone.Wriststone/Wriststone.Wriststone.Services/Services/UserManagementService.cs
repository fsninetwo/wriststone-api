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
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserManagementService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IList<UsersManagementDTO>> GetAllUsersAsync()
        {
            var user = await _userRepository.GetAllUsers();

            var userModel = _mapper.Map<IList<UsersManagementDTO>>(user);

            return userModel;
        }

        public async Task UpdateUserAsync(UsersManagementDTO updatedUsers)
        {
            var user = await _userRepository.GetUserAsync(updatedUsers.Id);

            if (user is null)
            {
                throw new InternalException("User is not found");
            }

            var mergedUser = UserHelper.MergeUpdatedData(updatedUsers, user);
            
            await _userRepository.UpdateUser(mergedUser);

            _logger.LogDebug($"User {updatedUsers.Id} is updated");
        }
    }
}
