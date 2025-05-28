using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultFeaturedProductsViewComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public DefaultFeaturedProductsViewComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
    }
}
