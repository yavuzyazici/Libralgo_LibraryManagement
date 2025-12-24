using Libralgo.Business.Abstract;
using Libralgo.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Libralgo.UI.Controllers
{
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("categories/search")]
        public IActionResult Search(string query)
        {
            var categories = categoryService.TGetAll()
                .Where(c => string.IsNullOrEmpty(query) || c.CategoryName.ToLower().Contains(query.ToLower()))
                .OrderBy(c => c.CategoryName)
                .Take(20)
                .Select(c => new { id = c.Id, text = c.CategoryName })
                .ToList();

            return Ok(categories);
        }
    }
}
