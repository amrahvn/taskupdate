using Microsoft.AspNetCore.Mvc;

namespace LastBackProje.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
