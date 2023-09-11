using LastBackProje.DataAccesLAyer;
using LastBackProje.ViewModels.HomeVms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LastBackProje.ViewComponents
{
    public class HomeSliderViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public HomeSliderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliders = await _context.Sliders
               .Where(s => s.IsDeleted == false)
               .ToListAsync();

            return View(sliders);
        }
    }
}
