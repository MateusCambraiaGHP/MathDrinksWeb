using MathDrinks.Interfaces;
using MathDrinks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult GetSupplierId(int id)
        {
            var supplier = _db.Supplier.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
            return Ok(new { supplier?.Name });
        }

        public IActionResult Index()
        {
            IEnumerable<Supplier> objCategories = _db.Supplier.ToList();
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
            //Validate(obj);
            _db.Supplier.Add(obj);
            _db.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ///Está variavel auxiliar é pra instanciar as entidades produto e o supplier no supplier_product porque o include não estava instanciando
            ///produto
            var supplier_product = _db.Supplier_Product.AsNoTracking()
                .Where(c => c.SupplierId == id)
                .Include(sp => sp.supplier)
                .Include(sp => sp.product);
            ///pegando o fornecedor do banco de dados onde o id passado no construtor é igual ao id do fornecedor da tabela 
            var supplierFromDb = _db.Supplier.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
            ///supplierProduct instanciado e pronto para ser utilizado na tabela para mostrar no front end
            supplierFromDb.supplierProduct = supplier_product.ToList();

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

        private void Validate(Supplier supplier)
        {
            if (String.IsNullOrEmpty(supplier.CNPJ) || supplier.CNPJ.Length != 18)
            {
                ModelState.AddModelError("CNPJ", "Insira um CNPJ válido.");
            }
        }
    }
}
