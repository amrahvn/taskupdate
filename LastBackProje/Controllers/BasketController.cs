
using LastBackProje.DataAccesLAyer;
using LastBackProje.Models;
using LastBackProje.ViewModels.BasketVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LastBackProje.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CardBasket(int? id)
        {

            ICollection<BasketVm> basket = await _context.Products.Select(p => new BasketVm()
            {
                Count = p.Count,
                Title = p.Title,
                ExTag = p.ExTag,

            }).ToListAsync();
            return View(basket);
        }

        public async Task<IActionResult> DeleteBasket(int ?id)
        {
            if (id == null) return BadRequest("id yanlisdir");

            if (!await _context.Products.AnyAsync(p => p.IsDeleted == false && p.Id == id)) return NotFound("not found");

            string? basket = Request.Cookies["basket"];
            List<BasketVm> basketVms = null;

           
            if (string.IsNullOrEmpty(basket))
            {
                return BadRequest("id tapilmadi");
            }

            basketVms = JsonConvert.DeserializeObject<List<BasketVm>>(basket);

            if (basketVms.Exists(b => b.Id != id))
            {
                return BadRequest("id basket icinde deyil");
            }

            basketVms.Remove(basketVms.Find(b => b.Id == id));

            basket = JsonConvert.SerializeObject(basketVms);

            Response.Cookies.Append("basket", basket);

            return PartialView("_BasketPartial", basketVms);
        }

        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id == null) return BadRequest("id yanlisdir");

            if (!await _context.Products.AnyAsync(p=>p.IsDeleted==false && p.Id==id)) return NotFound("not found");

            string? basket = Request.Cookies["basket"];
            List<BasketVm> basketVms = null;

            if (!string.IsNullOrEmpty(basket))
            {
                basketVms = JsonConvert.DeserializeObject<List<BasketVm>>(basket);

                if (basketVms.Exists(b => b.Id == id))
                {
                    basketVms.Find(b => b.Id == id).Count += 1;
                }
                else
                {

                    basketVms.Add(new BasketVm
                    {
                        Id = (int)id,
                        Count = 1
                    });
                }
            }
            else
            {
                basketVms = new List<BasketVm> { new BasketVm

                        {
                             Id = (int)id,
                            Count = 1
                        }
                };
            }

            basket = JsonConvert.SerializeObject(basketVms);

            Response.Cookies.Append("basket", basket);

            foreach (BasketVm basketVm in basketVms)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVm.Id);

                basketVm.Title = product.Title;
                basketVm.Image = product.MainImage;
                basketVm.Price = product.DisCountPrice > 0 ? product.DisCountPrice : product.Price;
                basketVm.ExTag= product.ExTag;
            }

            return PartialView("_BasketPartial", basketVms);
        }

    }
}


