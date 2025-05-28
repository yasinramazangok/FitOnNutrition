using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutFooterViewComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public UILayoutFooterViewComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }
    }
}
