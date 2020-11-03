using Autofac;
using NetCoreFramework.Core.DataAccess;
using NetCoreFramework.Core.DataAccess.EFCore;
using NetCoreFramework.Repository.Business.Abstract;
using NetCoreFramework.Repository.Business.Concrete;
using NetCoreFramework.Repository.DataAccess.Abstract;
using NetCoreFramework.Repository.DataAccess.Concrete.EFCore;

namespace NetCoreFramework.Repository.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Core Layer Dependencies
            builder.RegisterGeneric(typeof(EfEntityRepositoryBase<,>)).As(typeof(IEntityRepository<>));
            builder.RegisterGeneric(typeof(EfViewRepositoryBase<,>)).As(typeof(IViewRepository<>));
            builder.RegisterGeneric(typeof(EfQueryableRepositoryBase<>)).As(typeof(IQueryableRepository<>));

            // Business Layer Dependencies
            builder.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();

            // DataAccessDependencies
            builder.RegisterType<EfCountryDal>().As<ICountryDal>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();
        }
    }
}