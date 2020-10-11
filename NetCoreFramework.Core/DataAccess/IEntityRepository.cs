using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NetCoreFramework.Core.Entities;

namespace NetCoreFramework.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // ADD
        void Create(T entity);
        void CreateAsync(T entity);

        // ADD LIST
        void CreateRange(List<T> entities);
        void CreateRangeAsync(List<T> entities);


        // GET
        T Read(Expression<Func<T, bool>> filter);
        Task<T> ReadAsync(Expression<Func<T, bool>> filter);

        // GET LIST
        List<T> ReadRange(Expression<Func<T, bool>> filter = null);
        //Task<List<T>> ReadRangeAsync(Expression<Func<T, bool>> filter = null);


        // UPDATE
        void Update(T entity);
        void UpdateAsync(T entity);

        // UPDATE LIST
        void UpdateRange(List<T> entities);
        void UpdateRangeAsync(List<T> entities);


        // DELETE
        void Delete(T entity);
        void DeleteAsync(T entity);

        // DELETE LIST
        void DeleteRange(List<T> entities);
        void DeleteRangeAsync(List<T> entities);
    }
}