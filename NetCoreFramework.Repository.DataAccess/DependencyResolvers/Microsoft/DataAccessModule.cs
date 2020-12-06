using Microsoft.Extensions.DependencyInjection;
using NetCoreFramework.Core.Utilities.IoC;
using NetCoreFramework.Repository.DataAccess.Abstract;
using NetCoreFramework.Repository.DataAccess.Concrete.EFCore;

namespace NetCoreFramework.Repository.DataAccess.DependencyResolvers.Microsoft
{
    public class DataAccessModule : IModule
    {
        public void Load(IServiceCollection service)
        {
            service.AddSingleton<ICityDal, EfCityDal>();
            service.AddSingleton<ICountryDal, EfCountryDal>();
        }
    }
}