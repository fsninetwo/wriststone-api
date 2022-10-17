using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Enums;
using Wriststone.Wriststone.API.Attributes;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.API.Controllers
{
    [RequirePageAccess(PermissionEnum.UserManagement)]
    public class UserManagementController : BaseController
    {
        
    }
}
