using MathDrinks.Interfaces;
using MathDrinks.Models;
using Microsoft.AspNetCore.Mvc;

namespace MathDrinks.Controllers
{
    public class Supplier_ProductController : Controller
    {

        public readonly IApplicationMySqlDbContext _db;

        public Supplier_ProductController(IApplicationMySqlDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Supplier_Product> objCategories = _db.Supplier_Product.ToList();
            return View(objCategories);
        }

        public IActionResult Create()
        {
            Fill();
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
        private void Fill()
        {
            var products = _db.Product.AsNoTracking().ToList();
            ViewBag.Product = products.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
        }





    }
}
