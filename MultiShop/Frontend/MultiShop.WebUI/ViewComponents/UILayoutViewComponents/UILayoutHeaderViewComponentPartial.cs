using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutHeaderViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
