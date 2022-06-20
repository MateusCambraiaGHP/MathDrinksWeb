using MathDrinks.Interfaces;
using MathDrinks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MathDrinks.Controllers
{
    public class ProductController : Controller
    {
        public readonly IApplicationMySqlDbContext _db;

        public ProductController(IApplicationMySqlDbContext db)
        {
            _db = db;
        }

        // [HttpGet("syncprodutos")]
        public IActionResult GetProduct()
        {
            IEnumerable<Product> producsObj = _db.Product.ToList();
            return Ok(producsObj);
        }

        public IActionResult PostProduct(Product obj)
        {
            if (ModelState.IsValid)
            _db.Product.Add(obj);
            _db.Save();
            return Ok();
        }

        public IActionResult Index() 
        {
            IEnumerable<Product> producsObj = _db.Product.ToList();
            return View(producsObj);
        }
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj) 
        {
            if (ModelState.IsValid)
            _db.Product.Add(obj);
            _db.Save();
            TempData["success"] = "Produto criado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           
            var productFromDb = _db.Product.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            _db.Product.Update(obj);
            _db.Save();
            TempData["success"] = "Produto editado com sucesso.";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            var productFromDb = _db.Product.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Product.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
            if (obj == null) {
                return NotFound();
            }
            if (ModelState.IsValid)
            _db.Product.Remove(obj);
            _db.Save();
            TempData["success"] = "Produto deletado com sucesso.";
            return RedirectToAction("Index");
        }
    }
}