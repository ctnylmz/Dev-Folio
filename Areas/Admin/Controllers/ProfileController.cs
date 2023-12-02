﻿using Dev_Folio.Areas.Admin.Models;
using Dev_Folio.Data;
using Dev_Folio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dev_Folio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("Admin/Profile")]
        public async Task<IActionResult> Index()
        {
            var result = await _userManager.GetUserAsync(User);

            return View(result);
        }

        [Route("Admin/Profile")]
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            return RedirectToAction("Index");
        }
    }
}
