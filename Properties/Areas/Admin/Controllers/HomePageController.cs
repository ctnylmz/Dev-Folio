using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio_DevFolio.Data;
using Portfolio_DevFolio.Models;

namespace Portfolio_DevFolio.Areas.Admin.Controllers
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
