using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos.CouponDtos;
using MultiShop.Discount.Services.CouponServices;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponsController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCouponList()
        {
            var values = await _couponService.GetListAllCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(int id)
        {
            var values = await _couponService.GetByIdCouponAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _couponService.CreateCouponAsync(createCouponDto);
            return Ok("Kupon başarıyla oluşturuldu");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _couponService.DeleteCouponAsync(id);
            return Ok("Kupon başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _couponService.UpdateCouponAsync(updateCouponDto);
            return Ok("Kupon başarıyla güncellendi");
        }

        [HttpGet("GetCouponCodeDetailByCode")]
        public async Task<IActionResult> GetCouponCodeDetailByCode(string code)
        {
            var values = await _couponService.GetCouponDetailByCodeAsync(code);
            return Ok(values);
        }
    }
}
