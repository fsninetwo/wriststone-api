using System;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Wriststone.Data.Models
{
    public class UsersManagementEditDTO : UsersManagementDTO
    {
        public string FullName { get; set; }
    }
}
