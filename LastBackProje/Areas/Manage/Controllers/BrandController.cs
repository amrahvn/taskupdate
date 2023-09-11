using LastBackProje.DataAccesLAyer;
using LastBackProje.Models;
using LastBackProje.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LastBackProje.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int currentPage=1)
        {
            IQueryable<Brand> queries = _context.Brands
                .Include(b => b.products.Where(p => p.IsDeleted == false))
                .Where(b => b.IsDeleted == false)
                .OrderByDescending(c => c.Id);

            return View(PageNatedList<Brand>.Create(queries,currentPage,5,4));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) BadRequest();

            Brand brand=await _context.Brands
                .Include(b=>b.products.Where(p=>p.IsDeleted== false))
                .FirstOrDefaultAsync(b=>b.IsDeleted==false && b.Id==id);

            if(brand == null) return NotFound();

            return View(brand);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            if(!ModelState.IsValid) return View(brand);

            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }

  
}
