using System.Collections.Generic;
using System.Linq;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.Business.Abstract
{
    public interface ICountryService
    {
        List<Country> GetAll();

        Country GetById(short id);
        IQueryable<Country> QueryableList(/*short id*/);
        void Add(Country entity);
        void Update(Country entity);

        void TransactionalOperation(Country entity1, Country entity2);
    }
}