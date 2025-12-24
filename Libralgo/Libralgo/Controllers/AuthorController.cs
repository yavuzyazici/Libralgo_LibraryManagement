using Libralgo.Business.Abstract;
using Libralgo.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Libralgo.UI.Controllers
{
    public class AuthorController(IAuthorService authorService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("authors/search")]
        public IActionResult Search(string query)
        {
            var authors = authorService.TGetAll()
                .Where(a => string.IsNullOrEmpty(query) || a.NameSurname.ToLower().Contains(query.ToLower()))
                .OrderBy(a => a.NameSurname)
                .Take(20)
                .Select(a => new { id = a.Id, text = a.NameSurname })
                .ToList();

            return Ok(authors);
        }
    }
}
