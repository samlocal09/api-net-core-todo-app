using System;
using TodoListApp.Data.Common.Infrastructure;
using TodoListApp.Model.Common.EntityFramework.Common;

namespace TodoListApp.Data.Common.Repositories
{
    public class StateStatusRepository : RepositoryBase<StateStatus, Guid>, IStateStatusRepository
    {
        TodoAppNetCoreDBContext _context;

        public StateStatusRepository(TodoAppNetCoreDBContext context) : base(context)
        {
            _context = context;
        }
    }
}