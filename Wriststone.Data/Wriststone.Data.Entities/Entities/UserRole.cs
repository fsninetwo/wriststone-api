using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wriststone.Data.Entities.Entities
{
    public class UserRole
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> User { get; set; }

        [JsonIgnore]
        public virtual ICollection<PermissionMapping> PermissionMapping { get; set; }
    }
}
