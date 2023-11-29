using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio_DevFolio.Data;
using Portfolio_DevFolio.Models;

namespace Portfolio_DevFolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class AboutPageController : Controller
    {
        private DevfolioContext _context;

        public AboutPageController(DevfolioContext context)
        {
            _context = context;
        }

        [Route("Admin/About")]
        public IActionResult Index()
        {
            var about = _context.Abouts.FirstOrDefault();

            about.Skill = _context.Skills.ToList();

            return View(about);
        }

        [Route("Admin/About")]
        [HttpPost]
        public IActionResult Index(About about)
        {
            _context.Abouts.Update(about);
            
            _context.SaveChanges();

            TempData["Message"] = "Başarıyla Güncellendi";

            return RedirectToAction("Index");
        }


        [Route("Admin/Skill")]
        public IActionResult Skill()
        {
            var skill = _context.Skills.ToList();

            return View(skill);
        }

        [Route("Admin/Skill/Create")]
        public IActionResult SkillCreate()
        {
            var skill = _context.Skills.ToList();

            return View(skill);
        }


        [Route("Admin/Skill/Create")]
        [HttpPost]
        public IActionResult SkillCreate(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();

            return RedirectToAction("Skill");

        }


        [Route("Admin/Skill/Delete/{id}")]
        public IActionResult DeleteSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            _context.Remove(skill);
            _context.SaveChanges();

            return RedirectToAction("Skill");

        }



        [Route("Admin/Skill/Update/{id}")]
        public IActionResult SkillUpdate(int id)
        {
            var skill = _context.Skills.Find(id);

            return View(skill);
        }


        [Route("Admin/Skill/Update/{id}")]
        [HttpPost]
        public IActionResult SkillUpdate(Skill skill)
        {
            _context.Skills.Update(skill);
            _context.SaveChanges();

            return RedirectToAction("Skill");

        }
    }
}
