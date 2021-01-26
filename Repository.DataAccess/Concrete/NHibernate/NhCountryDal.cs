using Core.DataAccess.NHibernate;
using Repository.DataAccess.Abstract;
using Repository.Entities.Concrete;

namespace Repository.DataAccess.Concrete.NHibernate
{
    public class NhCountryDal : NhEntityRepositoryBase<Country>, ICountryDal
    {
        public NhCountryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}