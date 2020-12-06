using System.Reflection;
using Autofac;
using NetCoreFramework.Repository.Business.Abstract;
using NetCoreFramework.Repository.Business.Concrete;
using NetCoreFramework.Repository.DataAccess.Abstract;
using NetCoreFramework.Repository.DataAccess.Concrete.EFCore;
using Module = Autofac.Module;

namespace NetCoreFramework.Repository.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .SingleInstance();

            //builder.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
            //builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            
        }
    }
}