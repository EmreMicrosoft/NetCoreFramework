using System.Collections.Generic;
using System.Linq;
using Repository.Entities.Concrete;

namespace Repository.Business.Abstract
{
    public interface ICountryService
    {
        List<Country> GetAll();

        Country GetById(short id);
        IQueryable<Country> QueryableList(/*short id*/);
        void AddAsync(Country entity);
        void UpdateAsync(Country entity);

        void TransactionalOperation(Country entity1, Country entity2);
    }
}