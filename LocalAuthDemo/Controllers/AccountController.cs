using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LocalAuthDemo.Models;
using LocalAuthDemo.Services;
using LocalAuthDemo.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LocalAuthDemo.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly INodeService _nodeService;
        private SignInManager<User> _signManager;
        private UserManager<User> _userManager;

        public AccountController(INodeService nodeService, SignInManager<User> signManager, UserManager<User> userManager)
        {
            _nodeService = nodeService;
            _signManager = signManager;
            _userManager = userManager;
        }

        [Route("Login")]
        public IActionResult LogIn()
        {
            return View(new LogInViewModel());
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signManager.PasswordSignInAsync(model.UserName,
                   model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }

        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Register")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User{
                                        UserName = model.UserName,
                                        Email = model.Email,
                                        NodeId = await _nodeService.GetLastId()
                                    };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    await _signManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }

        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Route("LogOut")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}