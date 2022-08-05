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
    }
}
