using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio_DevFolio.Data;

namespace Portfolio_DevFolio.Areas.Admin.Controllers
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
