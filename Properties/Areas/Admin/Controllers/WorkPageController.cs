using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio_DevFolio.Data;
using Portfolio_DevFolio.Models;

namespace Portfolio_DevFolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class WorkPageController : Controller
    {
        DevfolioContext _context;

        public WorkPageController(DevfolioContext context)
        {
            _context = context;
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
        public IActionResult Create(Work work)
        {
            _context.Works.Add(work);
            _context.SaveChanges();

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
            var work = _context.Works.FirstOrDefault(x => x.Id == id);
            _context.Remove(work);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        [Route("/Admin/Work/Update/{id}")]
        [HttpPost]
        public IActionResult Update(Work work)
        {
            _context.Works.Update(work);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
