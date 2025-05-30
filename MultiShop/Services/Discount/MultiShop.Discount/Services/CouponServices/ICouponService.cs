using MultiShop.Discount.Dtos.CouponDtos;

namespace MultiShop.Discount.Services.CouponServices
{
    public interface ICouponService
    {
        Task<List<ResultCouponDto>> GetListAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
        Task<ResultCouponDto> GetCouponDetailByCodeAsync(string code);

    }
}
