using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Contexts;
using MultiShop.Cargo.EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Concretes
{
    public class CargoCompanyDal : GenericRepositoryDal<CargoCompany>, ICargoCompanyDal
    {
        public CargoCompanyDal(CargoContext cargoContext) : base(cargoContext)
        {

        }
    }
}
