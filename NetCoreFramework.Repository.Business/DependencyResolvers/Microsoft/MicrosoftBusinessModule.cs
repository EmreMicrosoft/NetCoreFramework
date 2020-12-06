using Microsoft.Extensions.DependencyInjection;
using NetCoreFramework.Repository.Business.Abstract;
using NetCoreFramework.Repository.Business.Concrete;

namespace NetCoreFramework.Repository.Business.DependencyResolvers.Microsoft
{
    public class MicrosoftBusinessModule
    {
        public void Load(IServiceCollection service)
        {
            service.AddSingleton<ICityService, CityManager>();
            service.AddSingleton<ICountryService, CountryManager>();
        }
    }
}