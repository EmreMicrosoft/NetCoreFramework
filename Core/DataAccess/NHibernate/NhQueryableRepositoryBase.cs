using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccess.NHibernate
{
    public class NhQueryableRepositoryBase<T> : IQueryableRepository<T>
        where T : class, IEntity, new()
    {
        private readonly NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;

        public NhQueryableRepositoryBase(NHibernateHelper nHibernateHelper, IQueryable<T> entities)
        {
            _nHibernateHelper = nHibernateHelper;
            _entities = entities;
        }


        public IQueryable<T> Table => Entities;

        //public Task<IQueryable<T>> TableAsync => EntitiesAsync;




        public virtual IQueryable<T> Entities =>
            _entities ??= _nHibernateHelper.OpenSession().Query<T>();

        public virtual Task<IQueryable<T>> EntitiesAsync =>
            Task.FromResult(_entities ??= _nHibernateHelper.OpenSession().Query<T>());
    }
}