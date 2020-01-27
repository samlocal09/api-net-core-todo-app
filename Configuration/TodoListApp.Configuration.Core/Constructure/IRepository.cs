using System.Linq;
using System;

namespace TodoListApp.Configuration.Core.Constructure
{
    public interface IRepository<T, PK> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Save(T entity);

        void Delete(T entity);

        void Commit();

        IQueryable<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties);
    }
}