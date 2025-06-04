using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.DiscountOfferServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultSpecialOfferSecondaryViewComponentPartial : ViewComponent
    {
        private readonly IDiscountOfferService _offerDiscountService;

        public DefaultSpecialOfferSecondaryViewComponentPartial(IDiscountOfferService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerDiscountService.GetAllDiscountOfferAsync();
            return View(values);
        }
    }
}
