using System.Collections.Generic;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.Business.Abstract
{
    public interface ICityService
    {
            List<City> GetAll();
            City GetById(int id);
            void Add(City entity);
            void Update(City entity);

            void TransactionalOperation(City entity1, City entity2);
    }
}