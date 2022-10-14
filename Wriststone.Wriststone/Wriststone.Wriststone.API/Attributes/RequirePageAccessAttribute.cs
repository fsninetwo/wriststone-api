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
        public AccessLevel? AccessLevel { get; set; }

        public Permission Permission { get; }

        public RequirePageAccessAttribute(Permission permission, AccessLevel accessLevel)
        {
            Permission = permission;
            AccessLevel = accessLevel;
        }

        public RequirePageAccessAttribute(Permission permission)
        {
            Permission = permission;
        }
        
    }
}
