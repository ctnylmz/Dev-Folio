using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dev_Folio.Data;
using Dev_Folio.Models;
using Microsoft.AspNetCore.Hosting;

namespace Dev_Folio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class WorkPageController : Controller
    {
        private DevFolioContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WorkPageController(DevFolioContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("Admin/Work")]
        public IActionResult Index()
        {
            var result = _context.Works.ToList();
            return View(result);
        }

        [Route("/Admin/Work/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/Admin/Work/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(Work work)
        {
            var newWork = new Work();

            newWork.Name = work.Name;
            newWork.Title = work.Title;
            newWork.Description = work.Description;
            newWork.Time = work.Time;

            if (work.Thumbnail != null)
            {
                newWork.ThumbnailUrl = UploadImage(work.Thumbnail);
            }
            else
            {
                newWork.ThumbnailUrl = "default.jpg";
            }

            await _context.Works.AddAsync(newWork);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [Route("/Admin/Work/Update/{id}")]
        public IActionResult Update(int id)
        {
            var work = _context.Works.FirstOrDefault(x => x.Id == id);
            return View(work);
        }

        [Route("/Admin/Work/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _context.Works.Find(id);

            if (result.ThumbnailUrl != "default.jpg")
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", result.ThumbnailUrl);

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _context.Works.Remove(result);

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        [Route("/Admin/Work/Update/{id}")]
        [HttpPost]
        public IActionResult Update(Work updatedWork, int id)
        {
            var existingWork = _context.Works.Find(id);

            if (existingWork == null)
            {
                return NotFound();
            }

            updatedWork.ThumbnailUrl = existingWork.ThumbnailUrl;

            existingWork.Name = updatedWork.Name;
            existingWork.Title = updatedWork.Title;
            existingWork.Description = updatedWork.Description;
            existingWork.Time = updatedWork.Time;

            _context.Works.Update(existingWork);
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
