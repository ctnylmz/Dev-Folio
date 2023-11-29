﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio_DevFolio.Areas.Admin.Models;
using Portfolio_DevFolio.Data;

namespace Portfolio_DevFolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly DevfolioContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, DevfolioContext context, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [Route("Login")]
        public async Task<IActionResult> Login()
        {
            if (!HttpContext.User.Identity!.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index", "Admin");

        }


        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Admin");

                }
                else
                {

                    ModelState.AddModelError("Email", "Email Or Password Hatalı");

                    return View(model);


                }
            }
            ModelState.AddModelError("Email", "Sistemde Problem Var");

            return View(model);
        }


    }
}
