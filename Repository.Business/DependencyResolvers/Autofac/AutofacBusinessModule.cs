using System.Reflection;
using Autofac;
using Repository.Business.Abstract;
using Repository.Business.Concrete;
using Repository.DataAccess.Abstract;
using Repository.DataAccess.Concrete.EFCore;
using Module = Autofac.Module;

namespace Repository.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
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