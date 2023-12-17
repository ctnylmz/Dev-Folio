using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dev_Folio.Data;
using Dev_Folio.Models;
using Microsoft.AspNetCore.Hosting;

namespace Dev_Folio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CertificatePageController : Controller
    {
        private DevFolioContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CertificatePageController(DevFolioContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Add(Certificate certificate)
        {
            var newCertificate = new Certificate();

            newCertificate.Name = certificate.Name;
            newCertificate.Title = certificate.Title;
            newCertificate.Description = certificate.Description;
            newCertificate.Time = certificate.Time;

            if (certificate.Thumbnail != null)
            {
                newCertificate.ThumbnailUrl = UploadImage(certificate.Thumbnail);
            }
            else
            {
                newCertificate.ThumbnailUrl = "default.jpg";
            }

            await _context.Certificates.AddAsync(newCertificate);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [Route("Admin/Certificate/Delete/{id}")]
        public IActionResult Add(int Id)
        {
            var result = _context.Certificates.Find(Id);

            if (result.ThumbnailUrl != "default.jpg")
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", result.ThumbnailUrl);

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

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

        private string UploadImage(IFormFile file)
        {
            var uniqueFileName = "";
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "img");

            uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

            var filePath = Path.Combine(folderPath, uniqueFileName);

            using (FileStream fileStream = System.IO.File.Create(filePath))
            {
                file.CopyTo(fileStream);
            }

            return uniqueFileName;
        }



    }
}
