using System;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.Models;

namespace Wriststone.Wriststone.Services.Helpers
{
    class UserHelper
    {
        public static User ConvertUserDTOtoUser(UserUpdateDTO user, UserGroup userGroup = UserGroup.User)
        {
            var newUser = new User
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                Created = DateTime.Now,
                UserGroup = userGroup,
            };

            return newUser;
        }
    }
}
