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
        private readonly DataDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountService
        (
            UserManager<AppUser> userManager,
            IConfiguration configuration,
            DataDbContext context
        )
        {
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
        }
        public async Task<ApiResponse> LoginAsync(LoginModel model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return new ApiResponse()
                {
                    Error = true,
                    Message = "Invalid token",
                    Success = false,
                    Data = null
                };
            }

            var token = GenerateJwt(model.Email);
            var AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            var RefreshToken = GenerateRefreshToken();
            var ExpirationDate = DateTime.UtcNow.AddSeconds(30);
            var TokenId = Guid.NewGuid().ToString();

            var tokenDB = new Token()
            {
                AccessToken = AccessToken,
                CreateAt = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddDays(30),
                RefreshToken = RefreshToken,
                TokenId = TokenId,
                User = user
            };

            await _context.AddAsync(tokenDB);
            await _context.SaveChangesAsync();

            return new ApiResponse()
            {
                Error = false,
                Message = "Invalid token",
                Success = true,
                Data = new TokenModel()
                {
                    AccessToken = AccessToken,
                    RefreshToken = RefreshToken,
                    ExpirationDate = ExpirationDate,
                    TokenId = TokenId
                }
            };
        }


        public async Task<IdentityResult> RegisterAsync(RegisterModel model)
        {
            var user = new AppUser
            {
                Email = model.Email,
                UserName = model.Email
            };

            return await _userManager.CreateAsync(user, model.Password);
        }

        // public async Task<ApiResponse> RefreshAsync(TokenModel model)
        // {
        //     var principal = GetPrincipalFromExpiredToken(model.AccessToken);
        //     var emailClaim = principal?.FindFirst(ClaimTypes.Email)?.Value;

        //     if (emailClaim is null)
        //         return new ApiResponse()
        //         {
        //             Error = true,
        //             Message = "Invalid token",
        //             Success = false,
        //             Data = null
        //         };

        //     var user = await _userManager.FindByEmailAsync(emailClaim);
        //     var checkToken = await _context.Tokens.Include(u => u.User)
        //         .FirstOrDefaultAsync(u => u.UserId == user.Id && u.AccessToken == model.AccessToken && u.RefreshToken == model.RefreshToken);

        //     if (checkToken is null || checkToken.ExpirationDate < DateTime.UtcNow)
        //         return new ApiResponse()
        //         {
        //             Error = true,
        //             Message = "Invalid token",
        //             Success = false,
        //             Data = null
        //         };

        //     var token = GenerateJwt(emailClaim);
        //     var AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
        //     var RefreshToken = GenerateRefreshToken();
        //     var ExpirationDate = DateTime.UtcNow.AddSeconds(30);
        //     var TokenId = Guid.NewGuid().ToString();

        //     checkToken.AccessToken = AccessToken;
        //     checkToken.CreateAt = DateTime.UtcNow;
        //     checkToken.ExpirationDate = ExpirationDate;
        //     checkToken.RefreshToken = RefreshToken;

        //     _context.Update(checkToken);
        //     await _context.SaveChangesAsync();

        //     return new ApiResponse()
        //     {
        //         Error = false,
        //         Message = "Success refresh token",
        //         Success = true,
        //         Data = new TokenModel()
        //         {
        //             AccessToken = AccessToken,
        //             RefreshToken = RefreshToken,
        //             ExpirationDate = ExpirationDate,
        //             TokenId = TokenId

        //         }
        //     };
        // }


        // public async Task<ApiResponse> RevokeAsync(string username, string TokenId)
        // {
        //     var user = await _userManager.FindByNameAsync(username);
        //     if (user != null && TokenId != null)
        //     {
        //         var token = await _context.Tokens.Include(u => u.User)
        //             .FirstOrDefaultAsync(u => u.UserId == user.Id && u.TokenId == TokenId);

        //         _context.Tokens.Remove(token);
        //         await _context.SaveChangesAsync();

        //         return new ApiResponse()
        //         {
        //             Error = false,
        //             Message = "Success refresh token",
        //             Success = true,
        //             Data = null
        //         };

        //     }

        //     return new ApiResponse()
        //     {
        //         Error = true,
        //         Message = "Success refresh token",
        //         Success = false,
        //         Data = null
        //     };
        // }

        private JwtSecurityToken GenerateJwt(string Email)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddSeconds(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }


        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];

            using var generator = RandomNumberGenerator.Create();

            generator.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var secret = _configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured");

            var validation = new TokenValidationParameters
            {
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                ValidAudience = _configuration["JWT:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ValidateLifetime = false
            };

            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
        }
    }
}
