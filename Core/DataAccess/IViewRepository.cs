using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IViewRepository<T> where T : class, IView, new()
    {
        // GET
        T Get(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        // GET LIST
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        //Task<List<T>> ReadRangeAsync(Expression<Func<T, bool>> filter = null);
    }
}