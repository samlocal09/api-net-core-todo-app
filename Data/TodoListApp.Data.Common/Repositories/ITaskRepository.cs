using System;
using System.Collections.Generic;
using TodoListApp.Configuration.Core.Constructure;
using TodoListApp.Model.Common.EntityFramework.Common;

namespace TodoListApp.Data.Common.Repositories
{
    public interface ITaskRepository : IRepository<Task, Guid>
    {
        Task GetById(Guid Id);
        void CreateTask(Task model);
        void UpdateTask(Task model);
        void DeleteTask(Task model);
    }
}