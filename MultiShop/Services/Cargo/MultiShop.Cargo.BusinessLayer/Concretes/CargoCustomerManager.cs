using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concretes
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public void TDelete(int id)
        {
            _cargoCustomerDal.Delete(id);
        }

        public List<CargoCustomer> TGetListAll()
        {
            return _cargoCustomerDal.GetListAll();
        }

        public CargoCustomer TGetById(int id)
        {
            return _cargoCustomerDal.GetById(id);
        }

        public void TInsert(CargoCustomer entity)
        {
            _cargoCustomerDal.Insert(entity);
        }

        public void TUpdate(CargoCustomer entity)
        {
            _cargoCustomerDal.Update(entity);
        }
    }
}
