using TodoListApp.Configuration.Core.Constructure;

namespace TodoListApp.Data.Common.Infrastructure
{
    public class CommonUnitOfWork : IUnitOfWork
    {
        private readonly TodoAppNetCoreDBContext _context;

        public CommonUnitOfWork(TodoAppNetCoreDBContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}