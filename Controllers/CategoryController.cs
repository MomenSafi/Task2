using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC2.Data;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {

            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");


        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");


        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
        public IActionResult GetAllProduct(int id)
        {
            List<Product> categoryProducts = _db.products.Where(u => u.CategoryId == id).ToList();
            return View(categoryProducts);
        }
        public ActionResult Search(string query)
        {
            List<Category> filteredCategories = _db.Categories.Where(c => c.CategoryName.Contains(query)).ToList();
            List<Product> filteredProducts = _db.products.Where(p => p.ProductName.Contains(query)).ToList();

            ViewBag.FilteredCategories = filteredCategories;
            ViewBag.FilteredProducts = filteredProducts;

            return View("GetAllProduct", filteredProducts);
        }
    }
}
