using MultiShop.DtoLayer.Dtos.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByUserIdDto> GetCargoCustomerInfoAsync(string id);
    }
}
