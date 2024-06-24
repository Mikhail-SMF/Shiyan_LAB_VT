using Microsoft.AspNetCore.Mvc;
using Shiyan.UI.Services;
using Shiyan.UI.Services.CategoryService;
using Shiyan.UI.Services.InstrumentsService;

namespace Shiyan.UI.Controllers
{
    public class ProductController(ICategoryService categoryService, IProductService instrumentsService) : Controller
    {
        [Route("Catalog")]
        [Route("Catalog/{category}")]
        public async Task<IActionResult> Index(string? category, int pageNo = 1)
        {
            // получить список категорий
            var categoriesResponse = await
            categoryService.GetCategoryListAsync();
            // если список не получен, вернуть код 404
            if (!categoriesResponse.Success)
                return NotFound(categoriesResponse.ErrorMessage);
            // передать список категорий во ViewData
            ViewData["categories"] = categoriesResponse.Data;
            // передать во ViewData имя текущей категории
            var currentCategory = category == null ? "Все" : categoriesResponse.Data.FirstOrDefault(c => c.NormalizedName == category)?.Name;
            ViewData["currentCategory"] = currentCategory;
            var productResponse = await instrumentsService.GetInstrumentListAsync(category, pageNo);
            if (!productResponse.Success)
                ViewData["Error"] = productResponse.ErrorMessage;
            return View(productResponse.Data);
        }
    }
}
