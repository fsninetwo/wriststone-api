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

        public UserRole UserRole { get; set; }

        public Permission Permission { get; set; }

        public AccessLevel AccessLevel { get; set; }
    }
}
