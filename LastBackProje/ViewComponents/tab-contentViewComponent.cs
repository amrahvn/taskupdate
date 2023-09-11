using LastBackProje.DataAccesLAyer;
using LastBackProje.ViewModels.HomeVms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LastBackProje.ViewComponents
{
    public class tab_contentViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public tab_contentViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(HomeVm model)
        {

            model.categories = await _context.Categories
                 .Where(c => !c.IsDeleted && c.IsMain)
                 .ToListAsync();

            model.NewArrival = await _context.Products
                .Where(p => !p.IsDeleted && p.IsNewArrival)
                .ToListAsync();

            model.BestSeller = await _context.Products
                .Where(p => !p.IsDeleted && p.IsBestSeller)
                .ToListAsync();

            model.Featured = await _context.Products
                .Where(p => !p.IsDeleted && p.IsFeature)
                .ToListAsync();

            return View(model);
        }
    }
}
