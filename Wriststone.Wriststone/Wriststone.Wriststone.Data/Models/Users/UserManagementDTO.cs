using System;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Wriststone.Data.Models
{
    public class UserManagementDTO
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string UserRole { get; set; }
    }
}
