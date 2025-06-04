using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderOrderServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class OrderController : Controller
    {
        private readonly IOrderOrderService _orderOrderService;
        private readonly IUserService _userService;

        public OrderController(IOrderOrderService orderOrderService, IUserService userService)
        {
            _orderOrderService = orderOrderService;
            _userService = userService;
        }

        public async Task<IActionResult> GetOrderList()
        {
            var user = await _userService.GetUserInfo();
            var values = await _orderOrderService.GetOrdersByUserId(user.Id);
            return View(values);
        }
    }
}
