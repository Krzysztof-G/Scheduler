using System;
using System.Linq;
using System.Linq.Expressions;

namespace Schdeuler.Repository.Base
{
    /// <summary>
    /// Generic repository interface for specified entity.
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IGenericRepository<T> : IRepository 
        where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        void Save();
    }
}
