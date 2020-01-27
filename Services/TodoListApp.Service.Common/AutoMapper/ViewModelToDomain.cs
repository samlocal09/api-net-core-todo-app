using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TodoListApp.Model.Common.EntityFramework.Common;
using TodoListApp.Service.Common.ViewModels.MasterData;

namespace TodoListApp.Service.Common.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<TaskViewModel, Task>()
                .ConstructUsing(c => new Task(c.Name, c.Description, c.StartDateAt, c.FinishedDateAt, c.ThumbTask));
        }
    }
}
