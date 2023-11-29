using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio_DevFolio.Data;
using Portfolio_DevFolio.Models;

namespace Portfolio_DevFolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CertificatePageController : Controller
    {
        private DevfolioContext _context;

        public CertificatePageController(DevfolioContext context)
        {
            _context = context;
        }

        [Route("Admin/Certificate")]
        public IActionResult Index()
        {
            var result = _context.Certificates.ToList();
            return View(result);
        }


        [Route("Admin/Certificate/Create")]
        public IActionResult Add()
        {
            return View();
        }

        [Route("Admin/Certificate/Create")]
        [HttpPost]
        public IActionResult Add(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [Route("Admin/Certificate/Delete/{id}")]
        public IActionResult Add(int Id)
        {
            var result = _context.Certificates.Find(Id);

            _context.Certificates.Remove(result);

            _context.SaveChanges();

            return RedirectToAction("Index");

        }


        [Route("Admin/Certificate/Update/{id}")]
        public IActionResult Update(int id)
        {
            var result = _context.Certificates.Find(id);
            return View(result);
        }

        [Route("Admin/Certificate/Update/{id}")]
        [HttpPost]
        public IActionResult Update(Certificate certificate)
        {
            _context.Certificates.Update(certificate);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
