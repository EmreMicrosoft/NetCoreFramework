using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Logging;
using Core.Aspects.AutoFac.Performance;
using Core.Aspects.AutoFac.Transaction;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCutting.Caching.Microsoft;
using Core.CrossCutting.Logging.Log4Net.Loggers;
using Repository.Business.Abstract;
using Repository.Business.Aspects.Security;
using Repository.Business.ValidationRules.FluentValidation;
using Repository.DataAccess.Abstract;
using Repository.Entities.Concrete;

namespace Repository.Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }


        [LogInterceptionAspect(typeof(FileLogger))]
        [SecurityOperationInterceptorAspect("City.Read")]
        [PerformanceInterceptionAspect(0)]
        [CacheInterceptionAspect(typeof(MemoryCacheManager))]
        public List<City> GetAll()
        {
            return _cityDal.GetList();
        }


        public async Task<City> GetById(int id)
        {
            return await _cityDal.GetAsync(x => x.Id == id);
        }


        [TransactionInterceptionAspect]
        [CacheRemoveInterceptionAspect("*Get*")]
        [ValidationInterceptionAspect(typeof(CityValidator))]
        public void Add(City product)
        {
            _cityDal.Add(product);
        }
    }
}