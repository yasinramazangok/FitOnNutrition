using MultiShop.DtoLayer.Dtos.DiscountOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.DiscountOfferServices
{
    public interface IDiscountOfferService
    {
        Task<List<ResultDiscountOfferDto>> GetAllDiscountOfferAsync();
        Task CreateDiscountOfferAsync(CreateDiscountOfferDto createDiscountOfferDto);
        Task UpdateDiscountOfferAsync(UpdateDiscountOfferDto updateDiscountOfferDto);
        Task DeleteDiscountOfferAsync(string id);
        Task<UpdateDiscountOfferDto> GetByIdDiscountOfferAsync(string id);
    }
}
