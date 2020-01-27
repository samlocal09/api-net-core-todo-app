using System;
using System.Linq;
using System.Linq.Expressions;
using TodoListApp.Configuration.Core.Abstract;
using TodoListApp.Configuration.Core.Constructure;

namespace TodoListApp.Data.Common.Infrastructure
{
    public abstract class RepositoryBase<T, PK> : IRepository<T, PK>, IDisposable where T : EntityKeyBase
    {
        private readonly TodoAppNetCoreDBContext _context;

        public RepositoryBase(TodoAppNetCoreDBContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Update(entity);
        }

        public void Save(T entity)
        {
            _context.Update(entity);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            return items;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}