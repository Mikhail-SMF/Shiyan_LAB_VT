using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Instruments.Domain.Models;
using Shiyan.UI.Extensions;

namespace Shiyan.UI.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<Cart>("cart");
            return View(cart);
        }
    }
}