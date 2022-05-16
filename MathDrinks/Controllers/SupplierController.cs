using MathDrinks.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MathDrinks.Controllers
{
    public class SupplierController : Controller
    {
        public readonly IApplicationMySqlDbContext _db;

        public SupplierController(IApplicationMySqlDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }









    }
}
