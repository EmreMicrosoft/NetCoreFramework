using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreFramework.Core.Entities;

namespace NetCoreFramework.Core.DataAccess.EFCore
{
    public class EfViewRepositoryBase<TEntity, TContext> : IViewRepository<TEntity>
        where TEntity : class, IView, new()
        where TContext : DbContext, new()
    {
        // GET
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

        // GET ASYNC
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new TContext();
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }


        // GET LIST
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new TContext();
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }

        // GET LIST ASYNC (Not Recommended)
        //public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        //{
        //    await using var context = new TContext();
        //    return filter == null
        //        ? await context.Set<TEntity>().ToListAsync()
        //        : await context.Set<TEntity>().Where(filter).ToListAsync();
        //}
    }
}