using Microsoft.AspNetCore.Mvc;

namespace Agreat.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
