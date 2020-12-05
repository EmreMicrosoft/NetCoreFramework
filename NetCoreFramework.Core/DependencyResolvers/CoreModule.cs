using System.Diagnostics;
using NetCoreFramework.Core.CrossCuttingConcerns.Caching;
using NetCoreFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using NetCoreFramework.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreFramework.Core.DependencyResolvers
{
    public class CoreModule : IModule
    {
        public void Load(IServiceCollection service)
        {
            service.AddMemoryCache();
            service.AddSingleton<ICacheManager, MemoryCacheManager>();
            service.AddSingleton<Stopwatch>();
        }
    }
}