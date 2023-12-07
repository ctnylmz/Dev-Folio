using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dev_Folio.Areas.Admin.Controllers
{
    public class SharedController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public SharedController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<PartialViewResult> NavbarPartial()
        {

            return PartialView();
        }
    }
}
