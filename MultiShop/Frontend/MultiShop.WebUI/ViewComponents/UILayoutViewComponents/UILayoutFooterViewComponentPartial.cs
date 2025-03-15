using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutFooterViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
