using LastBackProje.DataAccesLAyer;
using LastBackProje.Models;
using LastBackProje.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;

namespace LastBackProje.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(int currentPage=1)
        {

            IQueryable<Product> products = _context.Products
                .Where(p => p.IsDeleted == false)
                .OrderByDescending(p => p.Id);

            return View(PageNatedList<Product>.Create(products,currentPage,8,3));
        }



        public async Task<IActionResult> search(string search, int? categoryid)
        {
            List<Product> products = null;

            if (categoryid != null && await _context.Categories.AnyAsync(c=>c.IsDeleted==false && c.Id == categoryid))
            {
                products = await _context.Products
               .Where(p => p.IsDeleted == false && p.CategoryId== (int)categoryid || (
               p.Title.ToLower().Contains(search.ToLower()) ||
               p.Brand != null ? p.Brand.Name.ToLower().Contains(search.ToLower()) : true)
               ).ToListAsync();
            }
            else
            {
                products = await _context.Products
                 .Where(p => p.IsDeleted == false || (
                 p.Title.ToLower().Contains(search.ToLower()) ||
                 p.Brand != null ? p.Brand.Name.ToLower().Contains(search.ToLower()) : true) ||
                 p.Category.Name.ToLower().Contains(search.ToLower())
                 ).ToListAsync();
            }

           return PartialView("_searchPartial", products);

        }


        public async Task<IActionResult> Modal(int? id)
        {
            if(id == null) return BadRequest("id yanlisdir");

            Product product =await _context.Products
                .Include(p=>p.productImages.Where(pi => pi.IsDeleted == false))
                .FirstOrDefaultAsync(p=>p.IsDeleted == false && p.Id == id);

            if(product == null) return NotFound();

            return PartialView("_ModalPartial",product);
        }

        


    }
}
