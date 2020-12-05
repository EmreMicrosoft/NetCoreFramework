using System;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreFramework.Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection service)
        {
            ServiceProvider = service.BuildServiceProvider();
            return service;
        }
    }
}