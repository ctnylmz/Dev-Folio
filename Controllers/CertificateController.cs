using Microsoft.AspNetCore.Mvc;
using Dev_Folio.Data;

namespace Portfolio_DevFolio.Controllers
{
    public class CertificateController : Controller
    {
        private DevFolioContext _context;

        public CertificateController(DevFolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Certificates.ToList();
            return View(result);
        }

        public IActionResult Details(int id)
        {
            var result = _context.Certificates.Find(id);
            return View(result);
        }
    }
}
