using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using NHibernate.Linq;

namespace Core.DataAccess.NHibernate
{
    public class NhEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly NHibernateHelper _nHibernateHelper;

        public NhEntityRepositoryBase(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }



        // ADD
        public void Add(TEntity entity)
        {
            _nHibernateHelper.OpenSession().Save(entity);

            ////   << ??? using bloğu olmadan da çalışıyor mu?>>
            //using var session = _nHibernateHelper.OpenSession();
            //session.Save(entity);
        }

        // ADD ASYNC
        public async void AddAsync(TEntity entity)
        {
            await _nHibernateHelper.OpenSession().SaveAsync(entity);
        }


        // ADD LIST
        public void AddList(List<TEntity> entities)
        {
            _nHibernateHelper.OpenSession().Save(entities);
        }

        //ADD LIST ASYNC
        public async void AddListAsync(List<TEntity> entities)
        {
            await _nHibernateHelper.OpenSession().SaveAsync(entities);
        }




        // GET
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _nHibernateHelper.OpenSession().Query<TEntity>().SingleOrDefault(filter);
        }

        // GET ASYNC
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _nHibernateHelper.OpenSession()
                            .Query<TEntity>().SingleOrDefaultAsync(filter);
        }


        // GET LIST
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _nHibernateHelper.OpenSession().Query<TEntity>().ToList()
                : _nHibernateHelper.OpenSession().Query<TEntity>().Where(filter).ToList();
        }


        // GET LIST ASYNC
        //public async Task<List<TEntity>> ReadRangeAsync(Expression<Func<TEntity, bool>> filter = null)
        //{
        //    return filter == null
        //        ? await _nHibernateHelper.OpenSession().Query<TEntity>().ToListAsync()
        //        : await _nHibernateHelper.OpenSession().Query<TEntity>().Where(filter).ToListAsync();
        //}




        // UPDATE
        public void Update(TEntity entity)
        {
            _nHibernateHelper.OpenSession().Update(entity);
        }

        // UPDATE ASYNC
        public async void UpdateAsync(TEntity entity)
        {
            await _nHibernateHelper.OpenSession().UpdateAsync(entity);
        }


        // UPDATE LIST
        public void UpdateList(List<TEntity> entities)
        {
            _nHibernateHelper.OpenSession().Update(entities);
        }

        // UPDATE LIST ASYNC
        public void UpdateListAsync(List<TEntity> entities)
        {
            _nHibernateHelper.OpenSession().UpdateAsync(entities);
        }




        // DELETE
        public void Delete(TEntity entity)
        {
            _nHibernateHelper.OpenSession().Delete(entity);
        }

        // DELETE ASYNC
        public async void DeleteAsync(TEntity entity)
        {
            await _nHibernateHelper.OpenSession().DeleteAsync(entity);
        }


        // DELETE LIST
        public void DeleteList(List<TEntity> entities)
        {
            _nHibernateHelper.OpenSession().Delete(entities);
        }

        // DELETE LIST ASYNC
        public async void DeleteListAsync(List<TEntity> entities)
        {
            await _nHibernateHelper.OpenSession().DeleteAsync(entities);
        }
    }
}