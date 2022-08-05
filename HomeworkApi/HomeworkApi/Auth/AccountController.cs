using AutoMapper;
using HomeworkApi.Base;
using HomeworkApi.Data;
using HomeworkApi.Dto;
using HomeworkApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HomeworkApi.Auth
{
    [ApiController]
    [Route("api/v1/homework/[controller]")]
    public class AccountController : BaseController<AccountDto, Account>
    {
        private readonly IAccountService _accountService;


        public AccountController(IAccountService accountService, IMapper mapper) : base(accountService, mapper)
        {
            this._accountService = accountService;
        }


        [HttpPost]
        [Authorize]
        public new async Task<IActionResult> CreateAsync([FromBody] AccountDto resource)
        {
            return await base.CreateAsync(resource);
        }

        [HttpGet("GetUserDetail")]
        [Authorize]
        public async Task<IActionResult> GetUserDetail()
        {
            var userId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            return await base.GetByIdAsync(int.Parse(userId));
        }

        [HttpPut("self-update/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] AccountDto resource)
        {
            return await base.UpdateAsync(id, resource);
        }

        [HttpPut("change-password/{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdatePasswordAsync(int id, [FromBody] UpdatePasswordRequest resource)
        {           
            // Check if the id belongs to me
            var identifier = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!identifier.Equals(id.ToString()))
                return BadRequest(new BaseResponse<AccountDto>("Account_Not_Permitted"));

            // Checking duplicate password
            if (resource.OldPassword.Equals(resource.NewPassword))
                return BadRequest(new BaseResponse<AccountDto>("Account_Not_Permitted"));

            var result = await _accountService.UpdatePasswordAsync(id, resource);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public new async Task<IActionResult> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }
        

    }
}
