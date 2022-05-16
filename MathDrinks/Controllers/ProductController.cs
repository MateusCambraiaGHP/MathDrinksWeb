using MathDrinks.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MathDrinks.Controllers
{
    public class ProductController : Controller
    {
        public readonly IApplicationMySqlDbContext _db;

        public ProductController(IApplicationMySqlDbContext db)
        {
            _db = db;
        }

        public IActionResult Index() 
        {  
           return View();
        }
    }
}
