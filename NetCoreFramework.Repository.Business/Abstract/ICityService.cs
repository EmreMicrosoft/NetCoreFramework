using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreFramework.Core.Business;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.Business.Abstract
{
    public interface ICityService : IServiceRepository<City>
    {
            List<City> GetAll();
            Task<City> GetById(int id);
    }
}