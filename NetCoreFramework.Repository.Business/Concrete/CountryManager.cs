﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreFramework.Core.Aspects.Postsharp.CacheAspects;
using NetCoreFramework.Core.Aspects.Postsharp.LogAspects;
using NetCoreFramework.Core.Aspects.Postsharp.ValidationAspects;
using NetCoreFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using NetCoreFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using NetCoreFramework.Core.DataAccess;
using NetCoreFramework.Repository.Business.Abstract;
using NetCoreFramework.Repository.Business.ValidationRules.FluentValidation;
using NetCoreFramework.Repository.DataAccess.Abstract;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;
        private readonly IQueryableRepository<Country> _queryableRepository;

        public CountryManager(ICountryDal countryDal, IQueryableRepository<Country> queryableRepository)
        {
            _countryDal = countryDal;
            _queryableRepository = queryableRepository;
        }

        [CacheAspect(typeof(MemoryCacheManager), 30)]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public List<Country> GetAll()
        {
            return _countryDal.GetList();
        }

        public Country GetById(short id)
        {
            return _countryDal.Get(x => x.Id == id);
        }

        public IQueryable<Country> QueryableList(/*short id*/)
        {
            //returns 'IQueryable<Country>' 
            //return _queryableRepository.Table.Where(x => x.Id == 1);
            return _queryableRepository.Table;
        }

        public async void AddAsync(Country entity)
        {
            await Task.Run(() => _countryDal.AddAsync(entity));
        }

        [FluentValidationAspect(typeof(CountryValidator))]
        public async void UpdateAsync(Country entity)
        {
            await Task.Run(() => _countryDal.UpdateAsync(entity));
        }

        public void TransactionalOperation(Country entity1, Country entity2)
        {
            // TODO
        }
    }
}