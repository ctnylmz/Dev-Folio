using Dev_Folio.Areas.Admin.Models;
using Dev_Folio.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dev_Folio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly DevFolioContext _context;

        public SettingsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, DevFolioContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [Route("/Admin/Settings")]
        public IActionResult Settings()
        {
            return View();
        }

        [Route("/Admin/Settings")]
        [HttpPost]
        public async Task<IActionResult> Settings(Password password)
        {
            if (ModelState.IsValid)
            {
                if (password.NewPassword == password.ConfirmPassword)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var changePasswordResult = await _userManager.ChangePasswordAsync(user, password.currentPassword, password.NewPassword);
                    if (changePasswordResult.Succeeded)
                    {
                        return RedirectToAction("Index","Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("currentPassword", "Eski Şifre Hatalı");
                    }
                }
                else
                {
                    ModelState.AddModelError("currentPassword", "Yeni Şife ve Tekrar Şifre Hatalı");
                }
            }

            return View();

        }
    }
}
