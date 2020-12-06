using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreFramework.Core.Aspects.AutoFac.Caching;
using NetCoreFramework.Core.Aspects.AutoFac.Logging;
using NetCoreFramework.Core.Aspects.AutoFac.Performance;
using NetCoreFramework.Core.Aspects.AutoFac.Transaction;
using NetCoreFramework.Core.Aspects.AutoFac.Validation;
using NetCoreFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using NetCoreFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using NetCoreFramework.Repository.Business.Abstract;
using NetCoreFramework.Repository.Business.Aspects.Security;
using NetCoreFramework.Repository.Business.ValidationRules.FluentValidation;
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