using System;
using System.Collections.Generic;
using System.Linq;
using TodoListApp.Model.Common.EntityFramework.Common;

namespace TodoListApp.Data.Common
{
    public class TaskInitialDB
    {
        private readonly TodoAppNetCoreDBContext _context;

        public TaskInitialDB(TodoAppNetCoreDBContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Tasks.Any())
            {
                var tasks = new List<Task>
                {
                    new Task {
                        Id = Guid.NewGuid(),
                        Name = "Create Api Get All Task",
                        Description = "Create Api Get All Task",
                        StartDateAt = new DateTime(2018, 7, 16),
                        FinishedDateAt = new DateTime(2018, 7, 18),
                        ThumbTask = null,
                        StatusKey = 0,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Guid.Parse("36d704bf-37c1-406f-9feb-079ce2c01f3f"),
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Guid.Parse("684cf93f-8672-4c3d-aeea-54d1ad2c8762")
                    },
                    new Task {
                        Id = Guid.NewGuid(),
                        Name = "Create Api Create Task",
                        Description = "Create Api Create Task",
                        StartDateAt = new DateTime(2018, 7, 16),
                        FinishedDateAt = new DateTime(2018, 7, 18),
                        ThumbTask = null,
                        StatusKey = 0,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Guid.Parse("36d704bf-37c1-406f-9feb-079ce2c01f3f"),
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Guid.Parse("684cf93f-8672-4c3d-aeea-54d1ad2c8762")
                    },
                    new Task {
                        Id = Guid.NewGuid(),
                        Name = "Create Api Delete Task",
                        Description = "Create Api Delete Task",
                        StartDateAt = new DateTime(2018, 7, 16),
                        FinishedDateAt = new DateTime(2018, 7, 18),
                        ThumbTask = null,
                        StatusKey = 0,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Guid.Parse("36d704bf-37c1-406f-9feb-079ce2c01f3f"),
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Guid.Parse("684cf93f-8672-4c3d-aeea-54d1ad2c8762")
                    }
                };
                _context.AddRange(tasks);
                _context.SaveChanges();
            }

            if (!_context.StateStatus.Any())
            {
                var stateStatuses = new List<StateStatus>
                {
                    new StateStatus {
                        Id = Guid.NewGuid(),
                        StatusKey = 0,
                        Description = "New",
                        IsActive  = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Guid.Parse("36d704bf-37c1-406f-9feb-079ce2c01f3f"),
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Guid.Parse("684cf93f-8672-4c3d-aeea-54d1ad2c8762")
                    },
                    new StateStatus {
                        Id = Guid.NewGuid(),
                        StatusKey = 1,
                        Description = "In Progress",
                        IsActive  = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Guid.Parse("36d704bf-37c1-406f-9feb-079ce2c01f3f"),
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Guid.Parse("684cf93f-8672-4c3d-aeea-54d1ad2c8762")
                    },
                    new StateStatus {
                        Id = Guid.NewGuid(),
                        StatusKey = 2,
                        Description = "Hold On",
                        IsActive  = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Guid.Parse("36d704bf-37c1-406f-9feb-079ce2c01f3f"),
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Guid.Parse("684cf93f-8672-4c3d-aeea-54d1ad2c8762")
                    },
                    new StateStatus {
                        Id = Guid.NewGuid(),
                        StatusKey = 3,
                        Description = "Completed",
                        IsActive  = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Guid.Parse("36d704bf-37c1-406f-9feb-079ce2c01f3f"),
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Guid.Parse("684cf93f-8672-4c3d-aeea-54d1ad2c8762")
                    },
                    new StateStatus {
                        Id = Guid.NewGuid(),
                        StatusKey = 4,
                        Description = "Closed",
                        IsActive  = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Guid.Parse("36d704bf-37c1-406f-9feb-079ce2c01f3f"),
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Guid.Parse("684cf93f-8672-4c3d-aeea-54d1ad2c8762")
                    },
                };
                _context.AddRange(stateStatuses);
                _context.SaveChanges();
            }
        }
    }
}