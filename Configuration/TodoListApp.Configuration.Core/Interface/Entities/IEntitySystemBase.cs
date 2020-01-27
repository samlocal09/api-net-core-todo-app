using System;

namespace TodoListApp.Configuration.Core.Interface
{
    public interface IEntitySystemBase
    {
        bool IsDeleted { get; set; }

        DateTime CreatedAt { get; set; }

        Guid CreatedBy { get; set; }

        DateTime UpdatedAt { get; set; }

        Guid UpdatedBy { get; set; }
    }
}