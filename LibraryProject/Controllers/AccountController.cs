using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LibraryProject.Models.ApplicationContext;
using LibraryProject.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Controllers
{
    public class AccountController : Controller
    {
        private LibraryContext db;
        public AccountController(LibraryContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user == null)
                {
                    // adding user to database
                    user = new User { Email = model.Email, Password = model.Password };
                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "User");
                    if (userRole != null)
                        user.Role = userRole;

                    db.Users.Add(user);
                    db.SaveChanges();

                    await Authenticate(user); // applying authenticate

                    return RedirectToAction("AdminPage", "Admin");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await
                    db.Users.Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("AdminPage", "Admin");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {


            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }


    }
}
