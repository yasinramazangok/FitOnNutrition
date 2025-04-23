using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.DiscountOfferDtos;
using MultiShop.Catalog.Services.DiscountOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountOffersController : ControllerBase
    {
        private readonly IDiscountOfferService _discountOfferService;

        public DiscountOffersController(IDiscountOfferService DiscountOfferService)
        {
            _discountOfferService = DiscountOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountOfferList()
        {
            var values = await _discountOfferService.GetAllDiscountOfferAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountOfferById(string id)
        {
            var values = await _discountOfferService.GetByIdDiscountOfferAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountOffer(CreateDiscountOfferDto createDiscountOfferDto)
        {
            await _discountOfferService.CreateDiscountOfferAsync(createDiscountOfferDto);
            return Ok("Özel Teklif başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscountOffer(string id)
        {
            await _discountOfferService.DeleteDiscountOfferAsync(id);
            return Ok("Özel Teklif başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountOffer(UpdateDiscountOfferDto updateDiscountOfferDto)
        {
            await _discountOfferService.UpdateDiscountOfferAsync(updateDiscountOfferDto);
            return Ok("Özel Teklif başarıyla güncellendi");
        }
    }
}
