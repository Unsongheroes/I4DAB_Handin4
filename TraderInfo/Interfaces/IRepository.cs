using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TraderInfo.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetItemAsync(string id);

        Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate);

        Task<T> UpdateItemAsync(string id, T item);

        Task<T> CreateItemAsync(T item);

        Task<T> DeleteItemAsync(string id);

    }
}