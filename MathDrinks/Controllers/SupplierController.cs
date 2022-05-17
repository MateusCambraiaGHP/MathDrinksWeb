using MathDrinks.Interfaces;
using MathDrinks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            IEnumerable<Supplier> objCategories = _db.Supplier.ToList();
            return View(objCategories);
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Supplier obj)
        {
            _db.Supplier.Add(obj);
            _db.Save();
            TempData["success"] = "Fornecedor criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var supplierFromDb = _db.Supplier.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

            if (supplierFromDb == null)
            {
                return NotFound();
            }

            return View(supplierFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Supplier obj)
        {
            if (ModelState.IsValid)
            _db.Supplier.Update(obj);
            _db.Save();
            TempData["success"] = "Fornecedor editado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var supplierFromDb = _db.Supplier.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

            if (supplierFromDb == null)
            {
                return NotFound();
            }

            return View(supplierFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Supplier.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
            if (ModelState.IsValid)
                _db.Supplier.Remove(obj);
            _db.Save();
            TempData["success"] = "Fornecedor deletado com sucesso.";
            return RedirectToAction("Index");
        }
    }
}
