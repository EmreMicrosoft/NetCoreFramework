using FluentValidation;
using NetCoreFramework.Repository.Business.ValidationRules.FluentValidation;
using NetCoreFramework.Repository.Entities.Concrete;
using Ninject.Modules;

namespace NetCoreFramework.Repository.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Country>>().To<CountryValidator>().InSingletonScope();
            Bind<IValidator<City>>().To<CityValidator>().InSingletonScope();
        }
    }
}