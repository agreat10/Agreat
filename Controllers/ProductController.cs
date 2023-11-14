using Agreat.Data;
using Agreat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace Agreat.Controllers
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
            IEnumerable<Product> objList = _db.Product;
            foreach (var obj in objList)
            {
                obj.Category = _db.Category.FirstOrDefault(u => u.Id == obj.CategoryId);
            }
            return View(objList);
        }

        /// <summary>
        /// Метод GET для операции Upsert
        /// </summary>
        /// <returns></returns>
        public IActionResult Upsert(int? id)
        {
            // Список категорий
            IEnumerable<SelectListItem> CategoryDropDown = _db.Category.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.CategoryDropDown = CategoryDropDown;
            Product product = new Product();
            if(id == null)
            {
                // this is for create
                return View(product);
            }
            else
            {
                product = _db.Product.Find(id);
                if(product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            
        }
        /// <summary>
        /// Метод POST для операции Upsert
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }

      

        /// <summary>
        /// Метод GET  для операции Delete
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        /// <summary>
        /// Метод POST для операции Delete
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {

                return NotFound();
            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
           
        }
    }
}
