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
        public CargoCustomer GetCargoCustomerByUserId(string id)
        {
            var context = new CargoContext();
            return context.CargoCustomers.Where(x => x.CargoUserId == id).FirstOrDefault();
        }
    }
}
