using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio_DevFolio.Data;
using Portfolio_DevFolio.Models;

namespace Portfolio_DevFolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContactPageController : Controller
    {
        DevfolioContext _context;

        public ContactPageController(DevfolioContext context)
        {
            _context = context;
        }

        [Route("Admin/Contact")]
        public IActionResult Index()
        {
            var result = _context.Contacts.FirstOrDefault();

            return View(result);
        }

        [Route("Admin/Contact")]
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            
            _context.Contacts.Update(contact);
            
            _context.SaveChanges();

            TempData["Message"] = "Başarıyla Güncellendi";

            return RedirectToAction("Index");
        }
    }
}
