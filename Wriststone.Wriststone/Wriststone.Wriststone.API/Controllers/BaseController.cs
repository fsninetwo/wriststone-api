using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Wriststone.Wriststone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly string _token;

        protected BaseController()
        {

        }

        protected BaseController(IHttpContextAccessor httpContextAccessor)
        {
            var tokenAuthorizationHeader = httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            if (tokenAuthorizationHeader.Count > 0) _token = tokenAuthorizationHeader.ToString().Substring(7);
        }
    }
}
