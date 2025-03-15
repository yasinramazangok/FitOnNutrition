using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutScriptViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
