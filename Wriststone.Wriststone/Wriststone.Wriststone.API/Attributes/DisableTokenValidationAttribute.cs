using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wriststone.Wriststone.API.Attributes
{
    [AttributeUsage((AttributeTargets.Class | AttributeTargets.Method))]

    public class DisableTokenValidationAttribute : Attribute
    {
    }
}
