using App.Data;
using App.Models;

using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using App.Models.ViewModels;
using App.Utilities;
using System.Text.Encodings.Web;

namespace App.Services.AccountService
{
    public class AccountService : IAccountService
    {

        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtService _iJwtService;
        private readonly EmailService _emailService;

        public AccountService
        (
            UserManager<AppUser> userManager,
            IJwtService iJwtService,
            IConfiguration config,
            EmailService emailService
        )
        {
            _userManager = userManager;
            _iJwtService = iJwtService;
            _config = config;
            _emailService = emailService;
        }
        public async Task<ApiResponse> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email!);
            Console.WriteLine("Email" + user?.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password!))
            {
                return new ApiResponse()
                {
                    Error = true,
                    Message = "Invalid user",
                    Success = false,
                    Data = null
                };
            }

            string token = _iJwtService.GenerateToken(user);

            return new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = new
                {
                    access_token = token,
                    email = user.Email,
                    id = user.Id,
                    username = user.UserName,
                }
            };
        }


        public async Task<IdentityResult> RegisterAsync(RegisterModel model)
        {
            var user = new AppUser
            {
                Email = model.Email,
                UserName = model.UserName
            };

            return await _userManager.CreateAsync(user, model.Password!);
        }

        public async Task<ApiResponse> ForgotPasswordAsync(string email, string domain)
        {
            var result = new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = { }
            };

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                result.Success = false;
                return result;
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetLink = $"{domain}/auth/reset-password?email={Uri.EscapeDataString(email!)}&token={Uri.EscapeDataString(token!)}";
            var safeLink = HtmlEncoder.Default.Encode(passwordResetLink);
            try
            {
                await _emailService.SendEmailAsync("ResetPassword.html", email, "forgot password", new { name = user.UserName, link = safeLink });
            }
            catch (Exception)
            {
                result.Success = false;
                return result;
            }
            return result;
        }
        public async Task<ApiResponse> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            var result = new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = { }
            };

            var user = await _userManager.FindByEmailAsync(model.Email!);
            Console.WriteLine('1');
            if (user == null)
            {
                result.Success = false;
                return result;
            }

            var res = await _userManager.ResetPasswordAsync(user, model.Token!, model.Password!);

            foreach (var error in res.Errors)
            {
                Console.WriteLine($"Code: {error.Code}, Description: {error.Description}");
            }
            if (!res.Succeeded)
            {
                result.Success = false;
                return result;
            }
            Console.WriteLine('3');
            return result;
        }


    }
}
