using NetCoreFramework.Core.DataAccess.NHibernate;
using NetCoreFramework.Repository.DataAccess.Abstract;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.DataAccess.Concrete.NHibernate
{
    public class NhCountryDal : NhEntityRepositoryBase<Country>, ICountryDal
    {
        public NhCountryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}