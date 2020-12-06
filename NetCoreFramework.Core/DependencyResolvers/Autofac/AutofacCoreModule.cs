namespace NetCoreFramework.Core.DependencyResolvers.Autofac
{
    public class AutofacCoreModule
    {
        // Core Layer Dependencies
        //builder.RegisterGeneric(typeof(EfEntityRepositoryBase<,>)).As(typeof(IEntityRepository<>));
        //builder.RegisterGeneric(typeof(EfViewRepositoryBase<,>)).As(typeof(IViewRepository<>));
        //builder.RegisterGeneric(typeof(EfQueryableRepositoryBase<>)).As(typeof(IQueryableRepository<>));

        //// Business Layer Dependencies
        //builder.RegisterType<AutomationManager>().As<IAutomationService>().SingleInstance();
        //builder.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
        //builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
        //builder.RegisterType<ModuleManager>().As<IModuleService>().SingleInstance();

        //// DataAccessDependencies
        //builder.RegisterType<EfAutomationDal>().As<IAutomationDal>().SingleInstance();
        //builder.RegisterType<EfCountryDal>().As<ICountryDal>().SingleInstance();
        //builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();
        //builder.RegisterType<EfModuleDal>().As<IModuleDal>().SingleInstance();
    }
}