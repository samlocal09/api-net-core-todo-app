using System;
using System.Collections.Generic;
using TodoListApp.Service.Common.ViewModels;
using TodoListApp.Service.Common.ViewModels.MasterData;

namespace TodoListApp.Service.Common.Interfaces
{
    public interface ITaskService
    {
        BaseResultsViewModel<TaskViewModel> GetTaskṣ̣̣();
        BaseResultViewModel<TaskViewModel> GetTaskById(Guid id);
        BaseResultViewModel<BaseTaskResultViewModel> Create(TaskViewModel model);
        BaseResultViewModel<BaseTaskResultViewModel> Update(TaskViewModel model);
        BaseResultViewModel<BaseTaskResultViewModel> Delete(Guid taskId);
    }
}