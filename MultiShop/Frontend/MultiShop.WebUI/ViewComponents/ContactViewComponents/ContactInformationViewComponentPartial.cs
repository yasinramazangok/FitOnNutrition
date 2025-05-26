using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ContactViewComponents
{
    public class ContactInformationViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}