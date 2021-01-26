using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // ADD
        void Add(T entity);
        void AddAsync(T entity);

        // ADD LIST
        void AddList(List<T> entities);
        void AddListAsync(List<T> entities);


        // GET
        T Get(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        // GET LIST
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        //Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);


        // UPDATE
        void Update(T entity);
        void UpdateAsync(T entity);

        // UPDATE LIST
        void UpdateList(List<T> entities);
        void UpdateListAsync(List<T> entities);


        // DELETE
        void Delete(T entity);
        void DeleteAsync(T entity);

        // DELETE LIST
        void DeleteList(List<T> entities);
        void DeleteListAsync(List<T> entities);
    }
}