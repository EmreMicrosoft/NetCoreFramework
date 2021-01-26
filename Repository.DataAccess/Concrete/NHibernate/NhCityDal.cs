using Core.DataAccess.NHibernate;
using Repository.DataAccess.Abstract;
using Repository.Entities.Concrete;

namespace Repository.DataAccess.Concrete.NHibernate
{
    public class NhCityDal : NhEntityRepositoryBase<City>, ICityDal
    {
        public NhCityDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}