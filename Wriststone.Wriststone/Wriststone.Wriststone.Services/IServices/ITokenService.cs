using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface ITokenService
    {
        string TokenRaw { get; set; }

        string TokenString { get; }

        string GetUserGroup();
    }
}
