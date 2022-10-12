using System;
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
    }
}
