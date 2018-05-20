using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProsumerInfo.Interfaces;

namespace ProsumerInfo.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public BaseRepository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual TEntity Add(TEntity entity)
        {            
            return Context.Set<TEntity>().Add(entity).Entity;
        }

        public virtual async Task<TEntity> GetAsync(object key)
        {
            return await Context.Set<TEntity>().FindAsync(key);
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstAsync(predicate);
        }

        public virtual TEntity Remove(TEntity entity)
        {
            return Context.Set<TEntity>().Remove(entity).Entity;
        }

        public virtual TEntity Update(TEntity entity, object key)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

    }
}
