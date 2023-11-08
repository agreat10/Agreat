using Agreat.Data;
using Agreat.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agreat.Controllers
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
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        /// <summary>
        /// Метод GET для операции CREATE
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            
            return View();
        }
        /// <summary>
        /// Метод POST для операции CREATE
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            _db.Category.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
