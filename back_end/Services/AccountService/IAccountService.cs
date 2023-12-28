using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Identity;

namespace App.Services.AccountService
{
    public interface IAccountService
    {
        public Task<IdentityResult> RegisterAsync(RegisterModel model);
        public Task<ApiResponse> LoginAsync(LoginModel model);
        public Task<ApiResponse> RefreshAsync(TokenModel model);
        public Task<ApiResponse> RevokeAsync(string username, string TokenId);
    }
}