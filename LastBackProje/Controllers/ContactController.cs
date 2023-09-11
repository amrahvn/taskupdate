using Microsoft.AspNetCore.Mvc;

namespace LastBackProje.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
