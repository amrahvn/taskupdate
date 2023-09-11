
using Microsoft.AspNetCore.Mvc;


namespace LastBackProje.ViewComponents
{
    public class FeatureViewComponent:ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
           return View();
        }

    }
}
