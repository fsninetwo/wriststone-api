using System;
using System.Collections.Generic;
using Wriststone.Common.Domain.Enums;

namespace Wriststone.Data.Entities.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public DateTime Created { get; set; }

        public long UserRoleId { get; set; }

        public UserRole UserRole { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
