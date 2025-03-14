using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Contexts;
using MultiShop.Cargo.EntityLayer.Concretes;

namespace MultiShop.Cargo.DataAccessLayer.Concretes
{
    public class CargoCustomerDal : GenericRepositoryDal<CargoCustomer>, ICargoCustomerDal
    {
        public CargoCustomerDal(CargoContext cargoContext) : base(cargoContext)
        {

        }
    }
}
