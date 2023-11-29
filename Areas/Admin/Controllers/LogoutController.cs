using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Dev_Folio.Data;

namespace Dev_Folio.Areas.Admin.Controllers
{
    public class LogoutController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly DevfolioContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogoutController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, DevfolioContext context, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
         
        [Route("/Admin/Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
        
    }
}
