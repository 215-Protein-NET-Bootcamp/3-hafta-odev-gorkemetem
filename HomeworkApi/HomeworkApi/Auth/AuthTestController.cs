using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Security.Claims;

namespace HomeworkApi
{
    [ApiController]
    [Route("api/v1/homework/[controller]")]
    public class AuthTestController : ControllerBase
    {
        public AuthTestController() : base()
        {

        }


        [HttpGet("NoToken")]
        public string NoToken()
        {
            return "NoToken";
        }

        [HttpGet("Authorize")]
        [Authorize]
        public string Authorize()
        {
            return "Authorize";
        }

        [Authorize]
        [HttpGet("Admin")]
        public string Admin()
        {
            return "Admin";
        }

        [Authorize]
        [HttpGet("Viewer")]
        public string Viewer()
        {
            return "Viewer";
        }


        [Authorize]
        [HttpGet("EditorQTNS")]
        public string EditorQTNS()
        {
            return "EditorQTNS";
        }

        [Authorize]
        [HttpGet("AdminViewer")]
        public string AdminViewer()
        {
            Log.Information($"{User.Identity?.Name}: get account and group data with account-Id is.");
           
            var userIdentify = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value;
            var userId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            return "AdminViewer";
        }
        
    }
}
