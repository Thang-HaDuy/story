using App.Models;
using App.Models.ViewModels;
using App.Services.AccountService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.Apis
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountControllerApi : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountControllerApi(IAccountService AccountService)
        {
            _accountService = AccountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterModel model)
        {
            var result = await _accountService.RegisterAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            var result = await _accountService.LoginAsync(model);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return Unauthorized();
        }


        // [HttpPost("Refresh")]
        // public async Task<IActionResult> RefreshAsync([FromBody] TokenModel model)
        // {
        //     var result = await _accountService.RefreshAsync(model);

        //     if (result.Success)
        //     {
        //         return Ok(result.Data);
        //     }
        //     return Unauthorized();
        // }

        // [Authorize]
        // [HttpDelete("Revoke")]
        // public async Task<IActionResult> RevokeAsync(string TokenId)
        // {
        //     var username = HttpContext.User.Identity?.Name;
        //     if (username is null)
        //         return Unauthorized();

        //     var result = await _accountService.RevokeAsync(username, TokenId);

        //     if (result.Success)
        //     {
        //         return Ok(result.Data);
        //     }
        //     return Unauthorized();
        // }
    }
}
