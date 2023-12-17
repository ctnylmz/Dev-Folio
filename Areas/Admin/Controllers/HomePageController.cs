using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dev_Folio.Data;
using Dev_Folio.Models;
using Microsoft.AspNetCore.Components.Routing;

namespace Dev_Folio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomePageController : Controller
    {
        private DevFolioContext _context;

        public HomePageController(DevFolioContext context)
        {
            _context = context;
        }

        [Route("Admin/Home")]
        public IActionResult Index()
        {
            var home = _context.Homes.FirstOrDefault();

            if (home == null)
            {
                var newHome = new Home
                {
                    Name = "",
                    Title = "",
                };

                _context.Homes.Add(newHome);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

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
