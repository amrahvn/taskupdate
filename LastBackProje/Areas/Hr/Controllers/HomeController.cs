using Microsoft.AspNetCore.Mvc;

namespace LastBackProje.Areas.Hr.Controllers
{
    public class HomeController : Controller
    {
        [Area("Hr")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
