using LastBackProje.Models;
using LastBackProje.ViewModels.BasketVMs;

namespace LastBackProje.Interfaces
{
    public interface ILayoutService
    {
        Task<Dictionary<string, string>> GetSettingsAsync();

        Task<List<Category>> GetCategoriesAsync();

       Task<List<BasketVm>> GetBasketsAsync();
    }
}
