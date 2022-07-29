using HomeworkApi.Base;
using Microsoft.AspNetCore.Mvc;
using ProteinApi.Service;
using Serilog;
using System;
using System.Threading.Tasks;

namespace HomeworkApi.Auth
{
    [ApiController]
    [Route("protein/v1/api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenManagementService tokenManagementService;

        public TokenController(ITokenManagementService tokenManagementService) : base()
        {
            this.tokenManagementService = tokenManagementService;
        }


        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] TokenRequest tokenRequest)
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            var result = await tokenManagementService.GenerateTokensAsync(tokenRequest, DateTime.UtcNow, userAgent);

            if (result.Success)
            {
                Log.Information($"Role {result.Response.Role}: is loged in.");
                return Ok(result);
            }

            return Unauthorized(result);
        }
    }
}
