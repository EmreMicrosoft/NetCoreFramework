using System.Diagnostics;
using NetCoreFramework.Core.CrossCuttingConcerns.Caching;
using NetCoreFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using NetCoreFramework.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using NetCoreFramework.Core.DataAccess;
using NetCoreFramework.Core.DataAccess.EFCore;

namespace NetCoreFramework.Core.DependencyResolvers
{
    public class CoreModule : IModule
    {
        public void Load(IServiceCollection service)
        {
            service.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<,>));
            service.AddScoped(typeof(IViewRepository<>), typeof(EfViewRepositoryBase<,>));
            service.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<,>));
            service.AddScoped(typeof(IQueryableRepository<>), typeof(EfViewRepositoryBase<,>));


            service.AddMemoryCache();
            service.AddSingleton<ICacheManager, MemoryCacheManager>();
            service.AddSingleton<Stopwatch>();
        }
    }
}