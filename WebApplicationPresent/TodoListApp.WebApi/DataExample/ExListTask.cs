using System;
using System.Collections.Generic;
using TodoListApp.WebApi.Models.MasterData;

namespace TodoListApp.WebApi.DataExample
{
    public class ExListTask
    {
        public List<TaskViewModel> GetListTask()
        {
            List<TaskViewModel> listTask = new List<TaskViewModel>();
            listTask.Add(new TaskViewModel
            {
                Id = Guid.Parse("37c3d63c-29b2-460c-b500-15b603a608d2"),
                Name = "Create API Add Task",
                Description = "Create API Add New Task For FE",
                StartDateAt = new DateTime(2018, 07, 21),
                FinishedDateAt = new DateTime(2018, 07, 25),
                ThumbTask = null
            });
            listTask.Add(new TaskViewModel
            {
                Id = Guid.Parse("1a96c623-ffe4-44c0-b184-61a5e3816650"),
                Name = "Create API Update Task",
                Description = "Create API Update Task For FE",
                StartDateAt = new DateTime(2018, 07, 21),
                FinishedDateAt = new DateTime(2018, 07, 25),
                ThumbTask = null
            });
            listTask.Add(new TaskViewModel
            {
                Id = Guid.Parse("f938fe08-a577-49e8-86c9-0471caa7c9c4"),
                Name = "Update API Delete Task",
                Description = "Update API Delete Task, Set IsDelete = true",
                StartDateAt = new DateTime(2018, 07, 22),
                FinishedDateAt = new DateTime(2018, 07, 28),
                ThumbTask = null
            });
            listTask.Add(new TaskViewModel
            {
                Id = Guid.Parse("77162e99-6d5d-4d75-822f-ffeadbf72a6b"),
                Name = "Create API Search Task",
                Description = "Create API Search Task By Some Param",
                StartDateAt = new DateTime(2018, 07, 21),
                FinishedDateAt = new DateTime(2018, 07, 25),
                ThumbTask = null
            });
            listTask.Add(new TaskViewModel
            {
                Id = Guid.Parse("0189613f-4e5c-45c4-9083-dac5ccabbc69"),
                Name = "Create API Get Detail Task",
                Description = "Create API Get Detail Task By Id",
                StartDateAt = new DateTime(2018, 07, 21),
                FinishedDateAt = new DateTime(2018, 07, 25),
                ThumbTask = null
            });
            return listTask;
        }
    }
}