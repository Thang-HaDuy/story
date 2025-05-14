using App.Models;
using App.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Controller]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController
        (
            ILogger<AccountController> logger,
            SignInManager<AppUser> signInManager
        )
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        // GET: /Account/Login
        [HttpGet("/Login/")]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost("/Login/")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, false, false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "Tài khoản bị khóa");
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError("lỗi", "Không đăng nhập được.");
                    return View(model);
                }
            }
            return View(model);
        }


        [Route("/khongduoctruycap.html/")]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        // POST: /Account/LogOff
        [HttpPost("/logout/")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User đăng xuất");
            return RedirectToAction(nameof(Login));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }
}