using MultiShop.Catalog.Dtos.DiscountOfferDtos;

namespace MultiShop.Catalog.Services.DiscountOfferServices
{
    public interface IDiscountOfferService
    {
        Task<List<ResultDiscountOfferDto>> GetAllDiscountOfferAsync();
        Task CreateDiscountOfferAsync(CreateDiscountOfferDto createDiscountOfferDto);
        Task UpdateDiscountOfferAsync(UpdateDiscountOfferDto updateDiscountOfferDto);
        Task DeleteDiscountOfferAsync(string id);
        Task<GetByIdDiscountOfferDto> GetByIdDiscountOfferAsync(string id);
    }
}
