using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Concretes
{
    public class GenericRepositoryDal<T> : IGenericRepositoryDal<T> where T : class
    {
        private readonly CargoContext _cargoContext;

        public GenericRepositoryDal(CargoContext cargoContext)
        {
            _cargoContext = cargoContext;
        }
        public void Delete(int id)
        {
            var values = _cargoContext.Set<T>().Find(id);
            _cargoContext.Set<T>().Remove(values);
            _cargoContext.SaveChanges();
        }
        public List<T> GetListAll()
        {
            var values = _cargoContext.Set<T>().ToList();
            return values;
        }
        public T GetById(int id)
        {
            var value = _cargoContext.Set<T>().Find(id);
            return value;
        }
        public void Insert(T entity)
        {
            _cargoContext.Set<T>().Add(entity);
            _cargoContext.SaveChanges();
        }
        public void Update(T entity)
        {
            _cargoContext.Set<T>().Update(entity);
            _cargoContext.SaveChanges();
        }
    }
}
