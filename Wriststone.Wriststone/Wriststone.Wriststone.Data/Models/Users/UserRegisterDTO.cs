using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Wriststone.Data.Models.Users
{
    public class UserCreateDTO
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public DateTime Created { get; set; }

        public UserGroup UserGroup { get; set; }
    }
}
