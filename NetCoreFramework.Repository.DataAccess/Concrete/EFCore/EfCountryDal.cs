using NetCoreFramework.Core.DataAccess.EFCore;
using NetCoreFramework.Repository.DataAccess.Abstract;
using NetCoreFramework.Repository.DataAccess.Concrete.EFCore.DbContexts;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.DataAccess.Concrete.EFCore
{
    public class EfCountryDal : EfEntityRepositoryBase<Country, RepositoryContext>, ICountryDal
    {
    }
}