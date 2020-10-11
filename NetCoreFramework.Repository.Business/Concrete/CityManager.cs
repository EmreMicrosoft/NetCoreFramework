using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreFramework.Repository.Business.Abstract;
using NetCoreFramework.Repository.DataAccess.Abstract;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public List<City> GetAll()
        {
            return _cityDal.GetList();
        }

        public async Task<City> GetById(int id)
        {
            return await _cityDal.GetAsync(x => x.Id == id);
        }
    }
}