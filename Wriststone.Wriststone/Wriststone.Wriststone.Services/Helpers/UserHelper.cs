using System;
using Wriststone.Common.Domain.Enums;
using Wriststone.Common.Domain.Helpers;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Data.Models.Users;

namespace Wriststone.Wriststone.Services.Helpers
{
    public static class UserHelper
    {
        public static User MergeUpdatedData(UserUpdateDTO updatedUser, User user)
        {
            user.Email = updatedUser.Email;
            user.FullName = updatedUser.FullName;

            return user;
        }

        public static User MergeUpdatedData(UsersManagementDTO updatedUsers, User user)
        {
            user.Login = updatedUsers.Login;
            user.Email = updatedUsers.Email;
            user.UserRoleId = EnumHelper<UserRoleEnum>.ConvertToLong(updatedUsers.UserRole);

            return user;
        }
    }
}
