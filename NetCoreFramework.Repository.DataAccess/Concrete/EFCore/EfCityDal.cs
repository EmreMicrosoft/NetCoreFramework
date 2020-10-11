using NetCoreFramework.Core.DataAccess.EFCore;
using NetCoreFramework.Repository.DataAccess.Abstract;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.DataAccess.Concrete.EFCore
{
    public class EfCityDal : EfEntityRepositoryBase<City, RepositoryContext>, ICityDal
    {
    }
}