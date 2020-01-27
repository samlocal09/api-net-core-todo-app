using System;
using System.Collections.Generic;
using TodoListApp.Configuration.Core.Constructure;
using TodoListApp.Model.Common.EntityFramework.Common;

namespace TodoListApp.Data.Common.Repositories
{
    public interface IStateStatusRepository : IRepository<StateStatus, Guid>
    {
    }
}