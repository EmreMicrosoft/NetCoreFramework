using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Business;
using Repository.Entities.Concrete;

namespace Repository.Business.Abstract
{
    public interface ICityService : IServiceRepository<City>
    {
            List<City> GetAll();
            Task<City> GetById(int id);
    }
}