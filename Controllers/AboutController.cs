using Microsoft.AspNetCore.Mvc;
using Dev_Folio.Data;

namespace Dev_Folio.Controllers
{
    public class AboutController : Controller
    {
        private DevFolioContext _context;

        public AboutController(DevFolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var about = _context.Abouts.FirstOrDefault();

            about.Skill = _context.Skills.ToList();

            return View(about);
        }
    }
}
