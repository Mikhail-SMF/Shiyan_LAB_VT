using Instruments.Domain.Entities;
using Instruments.Domain.Models;

namespace Shiyan.UI.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<ResponseData<List<Category>>> GetCategoryListAsync();
    }
}
