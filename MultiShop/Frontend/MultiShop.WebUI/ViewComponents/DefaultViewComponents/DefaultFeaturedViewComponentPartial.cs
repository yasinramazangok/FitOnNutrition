using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultFeaturedViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
