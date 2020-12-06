using Autofac;
using NetCoreFramework.Core.DataAccess;
using NetCoreFramework.Core.DataAccess.EFCore;

namespace NetCoreFramework.Core.DependencyResolvers.Autofac
{
    public class AutofacCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Core Layer Dependencies
            builder.RegisterGeneric(typeof(EfEntityRepositoryBase<,>)).As(typeof(IEntityRepository<>));
            builder.RegisterGeneric(typeof(EfViewRepositoryBase<,>)).As(typeof(IViewRepository<>));
            builder.RegisterGeneric(typeof(EfQueryableRepositoryBase<>)).As(typeof(IQueryableRepository<>));
        }
    }
}