using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class ShoppingCartProductListViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
