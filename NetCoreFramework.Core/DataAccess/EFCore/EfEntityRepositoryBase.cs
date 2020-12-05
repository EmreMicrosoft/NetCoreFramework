using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreFramework.Core.Entities;

namespace NetCoreFramework.Core.DataAccess.EFCore
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        // ADD
        public void Add(TEntity entity)
        {
            using TContext context = new TContext();
            context.Add(entity);
            context.SaveChanges();
        }

        // ADD ASYNC
        public async void AddAsync(TEntity entity)
        {
            await using TContext context = new TContext();
            await Task.Run(() => context.AddAsync(entity));
            await context.SaveChangesAsync();
        }


        // ADD LIST
        public void AddList(List<TEntity> entities)
        {
            using TContext context = new TContext();
            context.AddRange(entities);
            context.SaveChanges();
        }

        // ADD LIST ASYNC
        public async void AddListAsync(List<TEntity> entities)
        {
            await using TContext context = new TContext();
            await Task.Run(() => context.AddRangeAsync(entities));
            await context.SaveChangesAsync();
        }




        // GET
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using TContext context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

        // GET ASYNC
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using TContext context = new TContext();
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }


        // GET LIST
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using TContext context = new TContext();
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }

        //// GET LIST ASYNC (Not Recommended)
        //   public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        //   {
        //       await using var context = new TContext();
        //       return filter == null
        //           ? await context.Set<TEntity>().ToListAsync()
        //           : await context.Set<TEntity>().Where(filter).ToListAsync();
        //   }




        // UPDATE
        public void Update(TEntity entity)
        {
            using TContext context = new TContext();
            context.Update(entity);
            context.SaveChanges();
        }

        // UPDATE ASYNC
        public async void UpdateAsync(TEntity entity)
        {
            await using TContext context = new TContext();
            await Task.Run(() => context.Update(entity));
            await context.SaveChangesAsync();
        }


        // UPDATE LIST
        public void UpdateList(List<TEntity> entities)
        {
            using TContext context = new TContext();
            context.UpdateRange(entities);
            context.SaveChanges();
        }

        // UPDATE LIST ASYNC
        public async void UpdateListAsync(List<TEntity> entities)
        {
            await using TContext context = new TContext();
            await Task.Run(() => context.UpdateRange(entities));
            await context.SaveChangesAsync();
        }




        // DELETE
        public void Delete(TEntity entity)
        {
            using TContext context = new TContext();
            context.Remove(entity);
            context.SaveChanges();
        }

        // DELETE ASYNC
        public async void DeleteAsync(TEntity entity)
        {
            await using TContext context = new TContext();
            await Task.Run(() => context.Remove(entity));
            await context.SaveChangesAsync();
        }


        // DELETE LIST
        public void DeleteList(List<TEntity> entities)
        {
            using TContext context = new TContext();
            context.RemoveRange(entities);
            context.SaveChanges();
        }

        // DELETE LIST ASYNC
        public async void DeleteListAsync(List<TEntity> entities)
        {
            await using TContext context = new TContext();
            await Task.Run(() => context.RemoveRange(entities));
            await context.SaveChangesAsync();
        }
    }
}