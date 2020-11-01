using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IspahaniBuzzerApp.Models.ViewModel;
using Dynamo.Data;
using Dynamo.Model.Common.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IspahaniBuzzerApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                //Find User
                var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                var isInRole = await _userManager.IsInRoleAsync(user, "Student");
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, false);
                    if (result.Succeeded)
                    {

                        if (user.Id == "8e09035f-c640-4ac0-8d5c-4a63d3eddfab")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if(isInRole)
                        {
                            return RedirectToAction("Buzzer", "Home");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Login Attempt");
                    }
                }
                else
                {
                    ModelState.TryAddModelError("", "UserName/Password Not Matched or Found");
                }
            }

            //Not found user or password did not matched            
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                //Create user
                var user = new ApplicationUser()
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email
                };
                //Create user with password
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                //Redirect User
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Users");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}