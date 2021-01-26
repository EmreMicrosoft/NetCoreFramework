using Microsoft.Extensions.DependencyInjection;
using Repository.Business.Abstract;
using Repository.Business.Concrete;

namespace Repository.Business.DependencyResolvers.Microsoft
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