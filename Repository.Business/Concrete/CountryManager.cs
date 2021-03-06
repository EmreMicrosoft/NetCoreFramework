﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess;
using Repository.Business.Abstract;
using Repository.Business.ValidationRules.FluentValidation;
using Repository.DataAccess.Abstract;
using Repository.Entities.Concrete;

namespace Repository.Business.Concrete
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