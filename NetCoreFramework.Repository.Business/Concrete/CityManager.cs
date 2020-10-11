using System.Collections.Generic;
using NetCoreFramework.Repository.Business.Abstract;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.Business.Concrete
{
    public class CityManager : ICityService
    {
        public List<City> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public City GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(City entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(City entity)
        {
            throw new System.NotImplementedException();
        }

        public void TransactionalOperation(City entity1, City entity2)
        {
            throw new System.NotImplementedException();
        }
    }
}