using Microsoft.AspNetCore.Mvc;
using MVC2.Data;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Product> objCategoryList = _db.products.ToList();
            ViewBag.Category = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            ViewBag.Category = _db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {

                _db.products.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "product created successfully";
                return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productsFromDb = _db.products.Find(id);
            ViewBag.Category = _db.Categories.ToList();

            ViewBag.SelectedCategory = productsFromDb.CategoryId;
            return View(productsFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
                _db.products.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "product updated successfully";
                return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productsFromDb = _db.products.Find(id);
            return View(productsFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _db.products.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.products.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
