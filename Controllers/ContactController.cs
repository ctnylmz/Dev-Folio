using Microsoft.AspNetCore.Mvc;
using Dev_Folio.Data;
using Dev_Folio.Models;

namespace Dev_Folio.Controllers
{
    public class ContactController : Controller
    {
        DevFolioContext _context;

        public ContactController(DevFolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Contacts.FirstOrDefault();

            return View(result);
        }

        [HttpPost]
        public IActionResult Index(Message message)
        {
            message.Time = DateTime.Now;
           
            message.Number = 1;

            _context.Messages.Add(message);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}
