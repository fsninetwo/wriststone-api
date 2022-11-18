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

        public static User MergeUpdatedData(UsersManagementEditDTO updatedUser, User user)
        {
            user.Login = updatedUser.Login;
            user.Email = updatedUser.Email;
            user.FullName = updatedUser.FullName;
            user.UserRoleId = EnumHelper<UserRoleEnum>.ConvertToLong(updatedUser.UserRole);

            return user;
        }
    }
}
