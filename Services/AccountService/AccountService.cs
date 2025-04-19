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

namespace App.Services.AccountService
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtService _iJwtService;

        public AccountService
        (
            UserManager<AppUser> userManager,
            IJwtService iJwtService
        )
        {
            _userManager = userManager;
            _iJwtService = iJwtService;
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
                Data = new { token }
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

    }
}
