using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class ProductDetailDescriptionViewComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailDescriptionViewComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return View(values);
        }
    }
}
