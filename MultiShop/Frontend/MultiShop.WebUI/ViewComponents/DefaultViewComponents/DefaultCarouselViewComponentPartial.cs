using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultCarouselViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
