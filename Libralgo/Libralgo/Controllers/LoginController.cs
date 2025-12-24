using Libralgo.Business.Abstract;
using Libralgo.Dto.UserDtos;
using Libralgo.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;

namespace Libralgo.UI.Controllers
{
    public class LoginController(IUserService userService) : Controller
    {
        [HttpGet("/register")]
        public IActionResult Register()
        {
            return View(new UserRegisterDto());
        }

        [ValidateAntiForgeryToken]
        [HttpPost("/register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var exists = userService.TGetAll().Any(u => u.MailAddress == dto.MailAddress);
            if (exists)
            {
                ModelState.AddModelError(nameof(dto.MailAddress), "Bu kullanıcı adı zaten kullanılıyor.");
                return View(dto);
            }

            userService.TCreate(dto);

            TempData["Success"] = "Kayıt başarılı. Giriş yapabilirsiniz.";
            return RedirectToAction("Login");
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View(new UserLoginDto());
        }

        [ValidateAntiForgeryToken]
        [HttpPost("/login")]
        public async Task<IActionResult> Login(UserLoginDto dto, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(dto);

            // Case-insensitive kullanıcı adı karşılaştırması istersen:
            var user = userService.GetByMail(dto.MailAddress);

            if (user is null || user.Password != dto.Password)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
                return View(dto);
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.MailAddress)
            // İleride role eklersen ClaimTypes.Role ekleyebilirsin
        };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties { IsPersistent = dto.RememberMe });

            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Admin");
        }
    }
}
