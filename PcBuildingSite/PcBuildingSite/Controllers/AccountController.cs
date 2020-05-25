using System;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PcBuildingSite.Models;

namespace PcBuildingSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register (RegisterViewModel registration)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = registration.Email,
                    Email = registration.Email
                };

                IdentityResult result = await this.userManager.CreateAsync(user, registration.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }

            }
            return View(registration);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await this.signInManager
                    .PasswordSignInAsync(
                    login.Email,                  
                    login.Password,
                    false,
                    false);

                if (result.Succeeded)
                {
                    return RedirectToAction("BuildComputer","Home");
                }

                ModelState.AddModelError("","Login unsuccesful");
            }
            return View(login);
        }
    }
}