using Microsoft.AspNetCore.Mvc;
using Dev_Folio.Data;

namespace Dev_Folio.Controllers
{
    public class WorkController : Controller
    {
        DevFolioContext _context;

        public WorkController(DevFolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var work = _context.Works.ToList();
            return View(work);
        }

        public IActionResult Details(int id)
        {
            var work = _context.Works.Find(id);
            return View(work);
        }
    }
}
