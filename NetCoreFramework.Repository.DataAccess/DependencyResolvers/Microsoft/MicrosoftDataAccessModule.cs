using Microsoft.Extensions.DependencyInjection;
using NetCoreFramework.Core.Utilities.IoC;
using NetCoreFramework.Repository.DataAccess.Abstract;
using NetCoreFramework.Repository.DataAccess.Concrete.EFCore;

namespace NetCoreFramework.Repository.DataAccess.DependencyResolvers.Microsoft
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