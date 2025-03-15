using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutTopbarViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
