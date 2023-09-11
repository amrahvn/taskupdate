using Microsoft.AspNetCore.Mvc;

namespace LastBackProje.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
