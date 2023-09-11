using LastBackProje.DataAccesLAyer;
using LastBackProje.Interfaces;
using LastBackProje.Models;
using LastBackProje.ViewModels.BasketVMs;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LastBackProje.Services
{
    public class LayoutService:ILayoutService
    {
        private readonly AppDbContext _context;

        private readonly IHttpContextAccessor _contextAccessor;

        public LayoutService(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<BasketVm>> GetBasketsAsync()
        {
            string cookie = _contextAccessor.HttpContext.Request.Cookies["basket"];

            List<BasketVm> basketVms = null;

            if(!string.IsNullOrEmpty(cookie) )
            {
                basketVms=JsonConvert.DeserializeObject<List<BasketVm>>(cookie);
            }
            else
            {
                basketVms=new List<BasketVm>();
            }

            foreach (BasketVm basketVm in basketVms)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVm.Id);

                basketVm.Title = product.Title;
                basketVm.Image = product.MainImage;
                basketVm.Price = product.DisCountPrice > 0 ? product.DisCountPrice : product.Price;
                basketVm.ExTag = product.ExTag;
            }

            return basketVms;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            List<Category> categories = await _context.Categories
                .Include(c=>c.Children.Where(ch=>ch.IsDeleted==false))
               .Where(c=>c.IsDeleted==false && c.IsMain==true).ToListAsync();

            return categories;
        }

        public async Task<Dictionary<string, string>> GetSettingsAsync()
        {
            Dictionary<string,string> settings=await _context.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);

            return settings;
        }
    }
}
