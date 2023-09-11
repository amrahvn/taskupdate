using Microsoft.AspNetCore.Mvc;

namespace LastBackProje.Areas.Marketing.Controllers
{
    [Area("marketing")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
