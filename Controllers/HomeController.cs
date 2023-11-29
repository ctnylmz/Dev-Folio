using Microsoft.AspNetCore.Mvc;
using Dev_Folio.Data;

namespace Dev_Folio.Controllers
{
    public class HomeController : Controller
    {
        private DevFolioContext _context;

        public HomeController(DevFolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var home = _context.Homes.Find(1);
            return View(home);
        }
    }
}
