﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Dev_Folio.Areas.Admin.Models;
using Dev_Folio.Data;

namespace Dev_Folio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly DevFolioContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, DevFolioContext context, IHttpContextAccessor httpContextAccessor)
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
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);

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