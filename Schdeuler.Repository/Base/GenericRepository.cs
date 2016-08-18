using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Schdeuler.Repository.Base
{
    /// <summary>
    /// Generic repository for specified entity.
    /// </summary>
    /// <typeparam name="C">DataBase context</typeparam>
    /// <typeparam name="T">Entity type</typeparam>
    public abstract class GenericRepository<C, T> : IGenericRepository<T>, IRepository
            where C : DbContext
            where T : class
    {
        protected readonly C Entities;

        public C Context
        {
            get
            {
                return this.Entities;
            }
        }

        public GenericRepository()
        {
            this.Entities = Activator.CreateInstance<C>();
        }

        public GenericRepository(IRepository existingRepository)
        {
            this.Entities = (existingRepository as GenericRepository<C, T>).Context;
        }
        
        public virtual IQueryable<T> GetAll()
        {
            return this.Entities.Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return Queryable.Where<T>(this.GetAll(), predicate);
        }

        public virtual void Add(T entity)
        {
            this.Entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            this.Entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            this.Entities.Entry<T>(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            this.Entities.SaveChanges();
        }
    }
}
