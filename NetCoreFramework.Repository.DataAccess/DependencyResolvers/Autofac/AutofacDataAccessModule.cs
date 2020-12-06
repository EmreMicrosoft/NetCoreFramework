using System.Reflection;
using Autofac;
using NetCoreFramework.Repository.DataAccess.Abstract;
using NetCoreFramework.Repository.DataAccess.Concrete.EFCore;
using Module = Autofac.Module;

namespace NetCoreFramework.Repository.DataAccess.DependencyResolvers.Autofac
{
    public class AutofacDataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
              .AsImplementedInterfaces()
              .SingleInstance();

            //builder.RegisterType<EfCountryDal>().As<ICountryDal>().SingleInstance();
            //builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();
            
        }
    }
}