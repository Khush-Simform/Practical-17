using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Practical_17.Models;
using System.Security.Claims;
using System.Xml.Linq;
using IdentityDemo.Data;
using System.Security.Principal;

namespace Practical_17.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthDbContext authDbContext;

        public AccountController(AuthDbContext authDbContext)
        {
            this.authDbContext = authDbContext;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                authDbContext.Users.Add(user);
                authDbContext.SaveChanges();
                return View("Login");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Fname, string Password)
        {
            if(ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Fname) && string.IsNullOrEmpty(Password))
                {
                    return RedirectToAction("Login");
                }
                ClaimsIdentity claimsIdentity = null;
                bool isAuthenticated = false;

                var user = authDbContext.Users.FirstOrDefault(x => x.Fname == Fname && x.Password == Password);
                if (user == null)
                {
                    ViewBag.Message = "User not Found!";
                    return View();
                }
                if (Fname == user?.Fname && Password == user?.Password && user.Role.ToString() == "Admin")
                {
                    claimsIdentity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, Fname),
                        new Claim(ClaimTypes.Role, "Admin")
                    },CookieAuthenticationDefaults.AuthenticationScheme);                    
                    isAuthenticated = true;
                }

                if (Fname == user?.Fname && Password == user?.Password && user.Role.ToString() == "Normal")
                {
                    claimsIdentity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, Fname),
                        new Claim(ClaimTypes.Role, "Normal")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                }
                if (isAuthenticated)
                {
                    ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
                    var loginDetail = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            var loginDetail = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
