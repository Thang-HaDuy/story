using System.Security.Claims;
using App.Models;
using App.Models.ViewModels;
using App.Services.AccountService;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.Apis
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AccountApiController(IAccountService AccountService) : ControllerBase
    {
        private readonly IAccountService _accountService = AccountService;

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterAsync(model);
                if (result.Succeeded)
                {
                    return Ok(result.Succeeded);
                }
            }

            return Unauthorized();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.LoginAsync(model);
                if (result.Success)
                {
                    result.StatusCode = 200;
                    return Ok(result);
                }
            }
            return Unauthorized();
        }
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                var currentUrl = HttpContext.Request.Headers["X-Subdomain"].FirstOrDefault();
                var result = await _accountService.ForgotPasswordAsync(model.Email!, currentUrl!);
                if (result.Success)
                {
                    return Ok(result);
                }
            }
            return Unauthorized();
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.ResetPasswordAsync(model);
                if (result.Success)
                {
                    return Ok(result);
                }
            }
            return Unauthorized();
        }

        [HttpGet("UserDetail")]
        public async Task<IActionResult> GetUserDetail()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = await _accountService.GetUserDetail(userId!);
                if (result.Success)
                {
                    return Ok(result);
                }
            }
            return Unauthorized();
        }


        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserModel model)
        {
            Console.WriteLine(model.Avatar);
            if (User.Identity?.IsAuthenticated == true)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = await _accountService.UpdateUser(userId!, model);
                if (result.Success)
                {
                    return Ok(result);
                }
            }
            return Unauthorized();
        }
    }
}
