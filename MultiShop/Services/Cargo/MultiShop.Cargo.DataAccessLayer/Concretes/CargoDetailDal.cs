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
    public class CargoDetailDal : GenericRepositoryDal<CargoDetail>, ICargoDetailDal
    {
        public CargoDetailDal(CargoContext cargoContext) : base(cargoContext)
        {
            
        }
    }
}
