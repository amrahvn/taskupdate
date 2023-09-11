using LastBackProje.Models;

namespace LastBackProje.ViewModels.HomeVms
{
    public class HomeVm
    {
        public IEnumerable<Slider> Sliders { get; set; }

        public IEnumerable<Category> categories { get; set; }

        public IEnumerable<Product> NewArrival { get; set; }

        public IEnumerable<Product> BestSeller { get; set; }

        public IEnumerable<Product> Featured { get; set; }
    }
}
