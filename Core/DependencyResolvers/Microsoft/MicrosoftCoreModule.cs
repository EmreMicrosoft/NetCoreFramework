using System.Diagnostics;
using Core.CrossCutting.Caching;
using Core.CrossCutting.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Core.DataAccess;
using Core.DataAccess.EFCore;

namespace Core.DependencyResolvers.Microsoft
{
    public class MicrosoftCoreModule : IModule
    {
        public void Load(IServiceCollection service)
        {
            service.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<,>));
            service.AddScoped(typeof(IViewRepository<>), typeof(EfViewRepositoryBase<,>));
            service.AddScoped(typeof(IQueryableRepository<>), typeof(EfQueryableRepositoryBase<>));


            service.AddMemoryCache();
            service.AddSingleton<ICacheManager, MemoryCacheManager>();
            service.AddSingleton<Stopwatch>();
        }
    }
}
