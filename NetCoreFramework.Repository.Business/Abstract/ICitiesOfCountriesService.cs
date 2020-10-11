using System.Collections.Generic;
using NetCoreFramework.Repository.Entities.ComplexTypes;

namespace NetCoreFramework.Repository.Business.Abstract
{
    public interface ICitiesOfCountriesService
    {
        List<CitiesOfCountries> GetAll();
    }
}