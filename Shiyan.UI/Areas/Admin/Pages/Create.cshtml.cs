using Instruments.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shiyan.UI.Services.CategoryService;
using Shiyan.UI.Services.InstrumentsService;

namespace Shiyan.UI.Areas.Admin.Pages
{
    public class CreateModel(ICategoryService categoryService, IProductService instrumentsService) : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            var categoryListData = await categoryService.GetCategoryListAsync();
            ViewData["CategoryId"] = new SelectList(categoryListData.Data, "Id", "Name");
            return Page();
        }
        [BindProperty]
        public Instrument Instrument { get; set; } = default!;

        [BindProperty]
        public IFormFile? Image { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult>
            OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await instrumentsService.CreateInstrumentAsync(Instrument, Image);
            return RedirectToPage("./Index");
        }
    }

}
