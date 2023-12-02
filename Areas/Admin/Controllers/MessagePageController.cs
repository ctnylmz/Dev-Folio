using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dev_Folio.Data;

namespace Dev_Folio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MessagePageController : Controller
    {
        DevFolioContext _context;

        public MessagePageController(DevFolioContext context)
        {
            _context = context;
        }

        [Route("/Admin/Message")]
        public IActionResult Index()
        {
            var result = _context.Messages.ToList();
            result.Reverse();
            return View(result);
        }

        [Route("/Admin/Message/Detail/{id}")]
        public IActionResult Details(int id)
        {
            var result = _context.Messages.Find(id);
            result.Number = 0;
            _context.SaveChanges();
            return View(result);
        }

        [Route("/Admin/Message/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _context.Messages.Find(id);

            _context.Messages.Remove(result);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
