using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wriststone.Data.Entities.Entities
{
    public class AccessLevel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<PermissionMapping> PermissionMapping { get; set; }
    }
}
