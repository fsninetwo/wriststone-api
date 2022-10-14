using System;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Wriststone.Data.Models
{
    public class UserDTO
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public UserGroup UserGroup { get; set; }

        public DateTime Created { get; set; }
    }
}
