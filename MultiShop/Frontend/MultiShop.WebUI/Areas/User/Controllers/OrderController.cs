using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class OrderController : Controller
    {
        public IActionResult GetOrderList()
        {
            return View();
        }
    }
}
