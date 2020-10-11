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
        public void Create(TEntity entity)
        {
            using var context = new TContext();
            context.Add(entity);
            context.SaveChanges();
        }

        // ADD ASYNC
        public async void CreateAsync(TEntity entity)
        {
            await using var context = new TContext();
            await Task.Run(() => context.AddAsync(entity));
            context.SaveChanges();
        }


        // ADD LIST
        public void CreateRange(List<TEntity> entities)
        {
            using var context = new TContext();
            context.AddRange(entities);
            context.SaveChanges();
        }

        // ADD LIST ASYNC
        public async void CreateRangeAsync(List<TEntity> entities)
        {
            await using var context = new TContext();
            await Task.Run(() => context.AddRangeAsync(entities));
            context.SaveChanges();
        }




        // GET
        public TEntity Read(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

        // GET ASYNC
        public async Task<TEntity> ReadAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new TContext();
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }


        // GET LIST
        public List<TEntity> ReadRange(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new TContext();
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }

        // GET LIST ASYNC
        //public async Task<List<TEntity>> ReadRangeAsync(Expression<Func<TEntity, bool>> filter = null)
        //{
        //    await using var context = new TContext();
        //    return filter == null
        //        ? await context.Set<TEntity>().ToListAsync()
        //        : await context.Set<TEntity>().Where(filter).ToListAsync();
        //}




        // UPDATE
        public void Update(TEntity entity)
        {
            using var context = new TContext();
            context.Update(entity);
            context.SaveChanges();
        }

        // UPDATE ASYNC
        public async void UpdateAsync(TEntity entity)
        {
            await using var context = new TContext();
            await Task.Run(() => context.Update(entity));
            context.SaveChanges();
        }


        // UPDATE LIST
        public void UpdateRange(List<TEntity> entities)
        {
            using var context = new TContext();
            context.UpdateRange(entities);
            context.SaveChanges();
        }

        // UPDATE LIST ASYNC
        public async void UpdateRangeAsync(List<TEntity> entities)
        {
            await using var context = new TContext();
            await Task.Run(() => context.UpdateRange(entities));
            context.SaveChanges();
        }




        // DELETE
        public void Delete(TEntity entity)
        {
            using var context = new TContext();
            context.Remove(entity);
            context.SaveChanges();
        }

        // DELETE ASYNC
        public async void DeleteAsync(TEntity entity)
        {
            await using var context = new TContext();
            await Task.Run(() => context.Remove(entity));
            context.SaveChanges();
        }


        // DELETE LIST
        public void DeleteRange(List<TEntity> entities)
        {
            using var context = new TContext();
            context.RemoveRange(entities);
            context.SaveChanges();
        }

        // DELETE LIST ASYNC
        public async void DeleteRangeAsync(List<TEntity> entities)
        {
            await using var context = new TContext();
            await Task.Run(() => context.RemoveRange(entities));
            context.SaveChanges();
        }
    }
}