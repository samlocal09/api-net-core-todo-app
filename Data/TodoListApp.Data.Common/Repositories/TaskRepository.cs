using System;
using System.Collections.Generic;
using System.Linq;
using TodoListApp.Data.Common.Infrastructure;
using TodoListApp.Model.Common.EntityFramework.Common;

namespace TodoListApp.Data.Common.Repositories
{
    public class TaskRepository : RepositoryBase<Task, Guid>, ITaskRepository
    {
        TodoAppNetCoreDBContext _context;

        public TaskRepository(TodoAppNetCoreDBContext context) : base(context)
        {
            _context = context;
        }

        public Task GetById(Guid Id)
        {
            return _context.Tasks.Where(t => t.Id == Id).FirstOrDefault();
        }

        public void CreateTask(Task entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = new Guid("be383b0f-f9a3-415f-89a9-e6d4f0a25685");
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = new Guid("be383b0f-f9a3-415f-89a9-e6d4f0a25685");

            _context.Add(entity);
        }

        public void UpdateTask(Task entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _context.Update(entity);
        }

        public void DeleteTask(Task entity)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.IsDeleted = true;

            _context.Update(entity);
        }
    }
}