using Microsoft.AspNetCore.Identity;

using App.Models.ViewModels;

namespace App.Services.AccountService
{
    public interface IAccountService
    {
        public Task<IdentityResult> RegisterAsync(RegisterModel model);
        public Task<ApiResponse> LoginAsync(LoginModel model);
        public Task<ApiResponse> ForgotPasswordAsync(string email, string domain);
        public Task<ApiResponse> ResetPasswordAsync(ResetPasswordViewModel model);
        public Task<ApiResponse> GetUserDetail(string id);
        public Task<ApiResponse> UpdateUser(string id, UpdateUserModel model);
        // public Task<ApiResponse> RefreshAsync(TokenModel model);
        // public Task<ApiResponse> RevokeAsync(string username, string TokenId);
    }
}
