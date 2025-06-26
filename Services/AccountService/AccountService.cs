using App.Models;
using Microsoft.AspNetCore.Identity;
using App.Models.ViewModels;
using System.Text.Encodings.Web;
using App.Utilities;

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

            var token = _iJwtService.GenerateToken(user);

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


        public async Task<IdentityResult> RegisterAsync(RegisterModel model, string domain)
        {
            var user = new AppUser
            {
                Email = model.Email,
                UserName = model.UserName,
                CreatedAt = DateTime.UtcNow
            };
            var result = await _userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var passwordResetLink = $"{domain}/auth/confirm-email?email={Uri.EscapeDataString(model.Email!)}&token={Uri.EscapeDataString(code!)}";
                var safeLink = HtmlEncoder.Default.Encode(passwordResetLink);
                await _emailService.SendEmailAsync("ConfirmEmail.html", model.Email, "Confirm Email", new { name = user.UserName, link = safeLink });
            }

            return result;
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
            if (user == null)
            {
                result.Success = false;
                return result;
            }

            var res = await _userManager.ResetPasswordAsync(user, model.Token!, model.Password!);

            if (!res.Succeeded)
            {
                result.Success = false;
                return result;
            }
            return result;
        }

        public async Task<ApiResponse> GetUserDetail(string id)
        {
            var result = new ApiResponse()
            {
                Error = false,
                Message = "",
                Success = true,
                Data = { }
            };

            if (id == null)
            {
                result.Success = false;
                return result;
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                result.Success = false;
                return result;
            }

            result.Data = new UserDetailViewModel()
            {
                Avatar = user.Avatar,
                CreatedAt = user.CreatedAt?.ToString("dd/MM/yyyy") ?? string.Empty,
                Email = user.Email,
                Gender = user.Gender,
                UserName = user.UserName
            };
            return result;
        }


        public async Task<ApiResponse> UpdateUser(string id, UpdateUserModel model)
        {
            var result = new ApiResponse
            {
                Error = false,
                Message = "",
                Success = true,
                Data = null
            };

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                result.Success = false;
                result.Error = true;
                result.Message = "User not found.";
                return result;
            }

            bool hasChanges = false;

            if (user.Gender != model.Gender)
            {
                user.Gender = model.Gender;
                hasChanges = true;
            }

            if (!string.IsNullOrEmpty(model.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetResult = await _userManager.ResetPasswordAsync(user, token, model.Password!);
                if (!resetResult.Succeeded)
                {
                    result.Success = false;
                    result.Error = true;
                    result.Message = string.Join(", ", resetResult.Errors.Select(e => e.Description));
                    return result;
                }
                hasChanges = true;
            }
            if (model.Avatar != null && model.Avatar.Length > 0)
            {
                user.Avatar = await UploadImage.UploadImageAsync("Image", "User", model.Avatar);
                hasChanges = true;
            }

            if (hasChanges)
            {
                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    result.Success = false;
                    result.Error = true;
                    result.Message = string.Join(", ", updateResult.Errors.Select(e => e.Description));
                    return result;
                }
            }

            result.Message = "Cập nhật thành công.";
            return result;
        }

        public async Task<ApiResponse> ConfirmEmailAsync(ConfirmEmailModel model)
        {
            var result = new ApiResponse
            {
                Error = false,
                Message = "",
                Success = true,
                Data = null
            };

            if (model.Email == null || model.Code == null)
            {
                result.Message = "User not found.";
                result.Success = false;
                return result;
            }


            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                result.Message = "User not found.";
                result.Success = false;
                return result;
            }
            var res = await _userManager.ConfirmEmailAsync(user, model.Code!);

            if (!res.Succeeded)
            {
                result.Success = false;
                return result;
            }
            return result;
        }
    }
}
