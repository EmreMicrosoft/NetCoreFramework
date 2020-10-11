using NetCoreFramework.Core.DataAccess;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.DataAccess.Abstract
{
    public interface ICountryDal : IEntityRepository<Country>
    {
    }
}