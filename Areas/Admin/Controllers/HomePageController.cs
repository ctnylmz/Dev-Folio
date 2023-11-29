using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dev_Folio.Data;
using Dev_Folio.Models;

namespace Dev_Folio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomePageController : Controller
    {
        private DevfolioContext _context;

        public HomePageController(DevfolioContext context)
        {
            _context = context;
        }

        [Route("Admin/Home")]
        public IActionResult Index()
        {
            var home = _context.Homes.Find(1);
            return View(home);
        }

        [Route("Admin/Home")]
        [HttpPost]
        public IActionResult Index(Home home)
        {
            _context.Homes.Update(home);
            _context.SaveChanges();

            TempData["Message"] = "Başarıyla Güncellendi";

            return RedirectToAction("Index");
        }
    }
}
