using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Wriststone.API.Attributes
{
    [AttributeUsage((AttributeTargets.Class | AttributeTargets.Method))]
    public class RequirePageAccessAttribute : Attribute
    {
        public AccessLevelEnum? AccessLevelEnum { get; set; }

        public PermissionEnum PermissionEnum { get; }

        public RequirePageAccessAttribute(PermissionEnum permissionEnum, AccessLevelEnum accessLevelEnum)
        {
            PermissionEnum = permissionEnum;
            AccessLevelEnum = accessLevelEnum;
        }

        public RequirePageAccessAttribute(PermissionEnum permissionEnum)
        {
            PermissionEnum = permissionEnum;
        }
        
    }
}
