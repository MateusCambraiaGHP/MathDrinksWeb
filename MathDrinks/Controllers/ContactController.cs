using MathDrinks.Interfaces;
using MathDrinks.Models;
using Microsoft.AspNetCore.Mvc;

namespace MathDrinks.Controllers
{
    public class ContactController : Controller
    {
        public readonly IApplicationMySqlDbContext _db;

        public ContactController(IApplicationMySqlDbContext db)
        {
            _db = db;
        }

        public IActionResult ContactForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateContact(Contact obj)
        {
            if (ModelState.IsValid)
            _db.Contact.Add(obj);
            _db.Save();
            TempData["success"] = "Contato enviado com sucesso.";
            return Ok();
        }
    }
}