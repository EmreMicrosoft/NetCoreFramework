using System.Reflection;
using Autofac;
using Repository.DataAccess.Abstract;
using Repository.DataAccess.Concrete.EFCore;
using Module = Autofac.Module;

namespace Repository.DataAccess.DependencyResolvers.Autofac
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