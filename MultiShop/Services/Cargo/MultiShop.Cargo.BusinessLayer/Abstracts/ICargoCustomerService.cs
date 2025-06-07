using MultiShop.Cargo.EntityLayer.Concretes;

namespace MultiShop.Cargo.BusinessLayer.Abstracts
{
    public interface ICargoCustomerService : IGenericService<CargoCustomer>
    {
        CargoCustomer TGetCargoCustomerByUserId(string id);
    }
}
