using System;
using CleanArchMvc.WebUI.ViewModels;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Controllers.ViewModel;
using CleanArchMVC.Domain.Interfaces.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.Controllers.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authentication;
        public AccountController(IAuthenticate authentication)
        {
            _authentication = authentication;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return Ok(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authentication.Authenticate(model.Email, model.Password);

            if (result)
            {
                if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return Ok("");
                }
                return Ok(model.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.(password must be strong).");
                return Ok(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await _authentication.RegisterUser(model.Email, model.Password);

            if (result)
            {
                return Ok("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt (password must be strong.");
                return Ok(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _authentication.Logout();
            return Ok(true);
        }
    }
}