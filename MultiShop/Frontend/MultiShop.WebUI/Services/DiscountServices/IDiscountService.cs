using MultiShop.DtoLayer.Dtos.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetCouponCodeDetailByCode> GetCouponCodeDetailByCode(string code);
        Task<int> GetCouponRateByCodeAsync(string code);
    }
}
