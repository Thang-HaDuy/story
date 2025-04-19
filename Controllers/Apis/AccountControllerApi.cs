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
    }
}
