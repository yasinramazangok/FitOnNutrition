using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultFeaturedProductsViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
