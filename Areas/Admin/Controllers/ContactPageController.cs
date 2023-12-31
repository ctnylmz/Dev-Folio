﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dev_Folio.Data;
using Dev_Folio.Models;

namespace Dev_Folio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContactPageController : Controller
    {
        DevFolioContext _context;

        public ContactPageController(DevFolioContext context)
        {
            _context = context;
        }

        [Route("Admin/Contact")]
        public IActionResult Index()
        {
            var result = _context.Contacts.FirstOrDefault();

            if (result == null)
            {
                var newContact = new Contact
                {
                    Address = "",
                    Phone = "",
                    Email = "",
                };

                _context.Contacts.Add(newContact);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

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
