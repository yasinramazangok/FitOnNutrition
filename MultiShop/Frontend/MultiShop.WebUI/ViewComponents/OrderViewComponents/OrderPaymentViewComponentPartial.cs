using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class OrderPaymentViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
