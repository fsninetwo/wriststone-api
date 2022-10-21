using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Wriststone.Common.Domain.Enums;

namespace Wriststone.Data.Entities.Entities
{
    public class PermissionMapping
    {
        public long Id { get; set; }

        public long UserRoleId { get; set; }

        public long PermissionId { get; set; }

        public long AccessLevelId { get; set; }

        public virtual UserRole UserRole { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual AccessLevel AccessLevel { get; set; }
    }
}
