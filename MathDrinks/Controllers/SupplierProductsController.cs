using MathDrinks.Interfaces;
using MathDrinks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MathDrinks.Controllers
{
    public class SupplierProductsController : Controller
    {

        public readonly IApplicationMySqlDbContext _db;

        public SupplierProductsController(IApplicationMySqlDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Supplier_Product> objSupplierProduct = _db.Supplier_Product.ToList();
            return View(objSupplierProduct);
        }

        public IActionResult Create(int SupplierId)
        {
            Fill();
            var model = new Supplier_Product { SupplierId = SupplierId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Supplier_Product obj)
        {
            _db.Supplier_Product.Add(obj);
            _db.Save();
            TempData["success"] = "Produto vinculado com sucesso.";
            return RedirectToAction("Index", "Supplier");
        }

        public IActionResult Edit(int id)
        {
            Fill();
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var supplierProducts = _db.Supplier_Product.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

            if (supplierProducts == null)
            {
                return NotFound();
            }
            return View(supplierProducts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Supplier_Product obj)
        {
            _db.Supplier_Product.Update(obj);
            _db.Save();
            TempData["success"] = "Edição feita com sucesso.";
            return RedirectToAction("Index", "Supplier");
        }

        public IActionResult Delete(int id)
        {
            Fill();
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var supplierProductFromDb = _db.Supplier_Product.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
            if (supplierProductFromDb == null)
            {
                return NotFound();
            }
            return View(supplierProductFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Supplier_Product.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
            if (ModelState.IsValid)
            _db.Supplier_Product.Remove(obj);
            _db.Save();
            TempData["success"] = "Produto deletado do fornecedor.";
            return RedirectToAction("Index");
        }
 
        private void Fill()
        {
            var products = _db.Product.AsNoTracking().ToList();
            ViewBag.Product = products.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
        }
    }
}