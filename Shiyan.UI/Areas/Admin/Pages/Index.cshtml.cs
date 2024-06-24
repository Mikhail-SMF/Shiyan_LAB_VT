using Instruments.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shiyan.UI.Services.InstrumentsService;

namespace Shiyan.UI.Areas.Admin.Pages
{
    [Authorize(Policy = "admin")]
    public class IndexModel : PageModel
    {
        private readonly IProductService _instrumentsService;
        public IndexModel(IProductService instrumentsService)
        {
            //_context = context;
            _instrumentsService = instrumentsService;
        }
        public List<Instrument> Instrument { get; set; } = default!;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public async Task OnGetAsync(int? pageNo = 1)
        {
            var response = await _instrumentsService.GetInstrumentListAsync(null, pageNo.Value);
            if (response.Success)
            {
                Instrument = response.Data.Items;
                CurrentPage = response.Data.CurrentPage;
                TotalPages = response.Data.TotalPages;
            }
        }
    }
}
