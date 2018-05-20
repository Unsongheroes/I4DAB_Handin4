using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProsumerInfo.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        Task<TEntity> GetAsync(object key);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();
        Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Remove(TEntity entity);
        TEntity Update(TEntity entity, object key);
    }
}