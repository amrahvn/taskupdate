using LastBackProje.DataAccesLAyer;
using LastBackProje.Models;
using LastBackProje.ViewComponents;
using LastBackProje.ViewModels.HomeVms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LastBackProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            HomeVm homeVm = new HomeVm
            {

                categories= await _context.Categories.Where(c => c.IsDeleted == false && c.IsMain == true).ToListAsync(),
    
            };
            
            return View(homeVm);
        }
    }
}
