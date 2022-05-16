using MathDrinks.Interfaces;
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

        public IActionResult Index() 
        { 
         return View();
        }

    }
}
