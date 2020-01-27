using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListApp.Configuration.Core.Constructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
