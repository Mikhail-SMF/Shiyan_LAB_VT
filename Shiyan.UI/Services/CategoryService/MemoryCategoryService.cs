using Instruments.Domain.Entities;
using Instruments.Domain.Models;

namespace Shiyan.UI.Services.CategoryService
{
    public class MemoryCategoryService : ICategoryService
    {
        public Task<ResponseData<List<Category>>> GetCategoryListAsync()
        {
            var categories = new List<Category>
            {
                new Category {Id=1, Name="Электроинструменты",NormalizedName="powerTools"},
                new Category {Id=2, Name="Ручной инструмент",NormalizedName="handTools"},
                new Category {Id=3, Name="Измерительный инструмент",NormalizedName="measuringTools"},
                new Category {Id=4, Name="Хозяйственный инструмент",NormalizedName="householdTools"},
            };

            var result = new ResponseData<List<Category>>();
            result.Data = categories;
            return Task.FromResult(result);
        }
    }
}
