using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using NetCoreFramework.Core.DataAccess;
using NetCoreFramework.Core.DataAccess.EFCore;
using NetCoreFramework.Core.DataAccess.NHibernate;
using NetCoreFramework.Repository.Business.Abstract;
using NetCoreFramework.Repository.Business.Concrete;
using NetCoreFramework.Repository.DataAccess.Abstract;
using NetCoreFramework.Repository.DataAccess.Concrete.EFCore;
using NetCoreFramework.Repository.DataAccess.Concrete.NHibernate.Helpers;

namespace NetCoreFramework.Repository.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<RepositoryContext>();

            Bind(typeof(IQueryableRepository<>))
                .To(typeof(EfQueryableRepositoryBase<>));

            Bind<NHibernateHelper>().To<SqlServerHelper>();


            // Repository.Business Layer Bindings:
            Bind<ICountryService>().To<CountryManager>().InSingletonScope();
            Bind<ICityService>().To<CityManager>().InSingletonScope();

            // Repository.DataAccess Layer Bindings:
            Bind<ICountryDal>().To<EfCountryDal>();
            Bind<ICityDal>().To<EfCityDal>();
        }
    }
}