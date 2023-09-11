using Microsoft.AspNetCore.Mvc;

namespace LastBackProje.ViewComponents
{
    public class NewsLetterViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
