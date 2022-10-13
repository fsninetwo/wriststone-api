using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wriststone.Data.Entities.Entities
{
    public class PermissionMapping
    {
        public long Id { get; set; }

        public UserGroup UserGroup { get; set; }

        public Permission Permission { get; set; }

        public AccessLevel AccessLevel { get; set; }
    }
}
