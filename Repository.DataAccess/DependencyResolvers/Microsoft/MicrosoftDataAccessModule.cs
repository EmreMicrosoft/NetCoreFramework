using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.IoC;
using Repository.DataAccess.Abstract;
using Repository.DataAccess.Concrete.EFCore;

namespace Repository.DataAccess.DependencyResolvers.Microsoft
{
    public class MicrosoftDataAccessModule : IModule
    {
        public void Load(IServiceCollection service)
        {
            service.AddSingleton<ICityDal, EfCityDal>();
            service.AddSingleton<ICountryDal, EfCountryDal>();
        }
    }
}