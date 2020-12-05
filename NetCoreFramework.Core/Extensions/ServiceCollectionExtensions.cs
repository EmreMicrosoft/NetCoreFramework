using System;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using log4net;
using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using NetCoreFramework.Core.Utilities.IoC;

namespace NetCoreFramework.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static IContainer _container;

        /// <summary>
        /// The parsing modules for each layer are added to the IServiceCollection.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="modules"></param>
        /// <returns></returns>
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection service, IModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(service);
            }

            return ServiceTool.Create(service);
        }


        /// <summary>
        /// Fills in the parses done on the IServiceCollection side.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="modules"></param>
        /// <returns></returns>
        public static IServiceCollection AddAutofacDependencyResolvers(this IServiceCollection services, Autofac.Module[] modules)
        {

            var builder = new ContainerBuilder();
            builder.Populate(services);

            foreach (var module in modules)
            {
                builder.RegisterModule(module);
            }

            _container = builder.Build();

            return services;
        }


        public static IServiceProvider CreateAutofacServiceProvider(this IServiceCollection services)
        {
            return new AutofacServiceProvider(_container);
        }


        public static IServiceCollection AddLog4Net(this IServiceCollection services)
        {
            // ERROR => if Log4Net version > 2.0.5 => TODO
            var assembly = Assembly.GetEntryAssembly();
            var logRepository = LogManager.GetRepository(assembly);
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            return services;
        }
    }
}