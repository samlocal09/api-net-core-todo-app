using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TodoListApp.Model.Common.EntityFramework.Common;
using TodoListApp.Service.Common.ViewModels.MasterData;

namespace TodoListApp.Service.Common.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Task, TaskViewModel>();
        }
    }
}
