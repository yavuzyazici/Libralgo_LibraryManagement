using Microsoft.AspNetCore.Mvc;

namespace Libralgo.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [Route("/admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
