using NetCoreFramework.Core.DataAccess.NHibernate;
using NetCoreFramework.Repository.DataAccess.Abstract;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.DataAccess.Concrete.NHibernate
{
    public class NhCityDal : NhEntityRepositoryBase<City>, ICityDal
    {
        public NhCityDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}