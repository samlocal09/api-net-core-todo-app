using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoListApp.Configuration.Core.Constructure;
using TodoListApp.Data.Common.Repositories;
using TodoListApp.Model.Common.EntityFramework.Common;
using TodoListApp.Service.Common.Interfaces;
using TodoListApp.Service.Common.ViewModels;
using TodoListApp.Service.Common.ViewModels.MasterData;

namespace TodoListApp.Service.Common.Services
{
    public class TaskService : ITaskService
    {
        #region Declaration

        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;
        private readonly IStateStatusRepository _stateStatusRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public TaskService(
            ITaskRepository taskRepository,
            IStateStatusRepository stateStatusRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _stateStatusRepository = stateStatusRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        public BaseResultsViewModel<TaskViewModel> GetTaskṣ̣̣()
        {
            var tasksQuery = _taskRepository.GetAll().Where(x => x.IsDeleted != true);
            var stateStatusesQuery = _stateStatusRepository.GetAll().Where(x => x.IsDeleted != true);

            var tasksResult = from taskItem in tasksQuery
                              join statusItem in stateStatusesQuery on taskItem.StatusKey equals statusItem.StatusKey
                              select new TaskViewModel
                              {
                                  Id                = taskItem.Id,
                                  Name              = taskItem.Name,
                                  Description       = taskItem.Description,
                                  StartDateAt       = taskItem.StartDateAt,
                                  FinishedDateAt    = taskItem.FinishedDateAt,
                                  ThumbTask         = taskItem.ThumbTask,
                                  Remark            = taskItem.Remark,
                                  EstimationTime    = taskItem.EstimationTime,
                                  StatusKey         = taskItem.StatusKey,
                                  StatusDescription = statusItem.Description,
                              };

            var resultsResponse = new BaseResultsViewModel<TaskViewModel>();
            if (tasksResult != null)
            {
                resultsResponse.Success = true;
                resultsResponse.Code = 200;
                resultsResponse.Result = tasksResult;

                return resultsResponse;
            }

            resultsResponse.Success = true;
            resultsResponse.Code = 404;
            resultsResponse.Result = null;

            return resultsResponse;
        }

        public BaseResultViewModel<TaskViewModel> GetTaskById(Guid id)
        {
            var task = _taskRepository.GetById(id);
            var resultResponse = new BaseResultViewModel<TaskViewModel>();
            if (task != null)
            {
                var taskViewModelResult = _mapper.Map<Task, TaskViewModel>(task);
                resultResponse.Success = true;
                resultResponse.Code = 200;
                resultResponse.Result = taskViewModelResult;

                return resultResponse;
            }

            resultResponse.Success = true;
            resultResponse.Code = 404;
            resultResponse.Result = null;

            return resultResponse;
        }

        public BaseResultViewModel<BaseTaskResultViewModel> Create(TaskViewModel model)
        {
            var taskModel = _mapper.Map<TaskViewModel, Task>(model);
            var resultResponse = new BaseResultViewModel<BaseTaskResultViewModel>();
            if (taskModel != null)
            {
                _taskRepository.CreateTask(taskModel);
                _taskRepository.Commit();
                //Response Result
                resultResponse = new BaseResultViewModel<BaseTaskResultViewModel>()
                {
                    Success = true,
                    Code = 201,
                    Result = new BaseTaskResultViewModel() { Id = taskModel.Id }
                };
                return resultResponse;
            }

            //Response Result
            resultResponse = new BaseResultViewModel<BaseTaskResultViewModel>()
            {
                Success = true,
                Code = 400,
                Result = null
            };

            return resultResponse;
        }

        public BaseResultViewModel<BaseTaskResultViewModel> Update(TaskViewModel model)
        {
            var _taskModel = _taskRepository.GetById(model.Id);
            var resultResponse = new BaseResultViewModel<BaseTaskResultViewModel>();

            if (_taskModel != null)
            {
                _taskModel.Name = model.Name;
                _taskModel.Description = model.Description;
                _taskModel.StartDateAt = model.StartDateAt;
                _taskModel.FinishedDateAt = model.FinishedDateAt;
                _taskModel.ThumbTask = model.ThumbTask;
                _taskModel.EstimationTime = model.EstimationTime;
                _taskModel.Remark = model.Remark;

                _taskRepository.UpdateTask(_taskModel);
                _taskRepository.Commit();

                //Response Result
                resultResponse = new BaseResultViewModel<BaseTaskResultViewModel>()
                {
                    Success = true,
                    Code = 200,
                    Result = new BaseTaskResultViewModel() { Id = _taskModel.Id }
                };
                return resultResponse;
            }

            //Response Result
            resultResponse = new BaseResultViewModel<BaseTaskResultViewModel>()
            {
                Success = true,
                Code = 400,
                Result = null
            };

            return resultResponse;
        }

        public BaseResultViewModel<BaseTaskResultViewModel> Delete(Guid taskId)
        {
            var _taskModel = _taskRepository.GetById(taskId);
            var resultResponse = new BaseResultViewModel<BaseTaskResultViewModel>();

            if (_taskModel != null)
            {
                _taskRepository.DeleteTask(_taskModel);
                _taskRepository.Commit();

                //Response Result
                resultResponse = new BaseResultViewModel<BaseTaskResultViewModel>()
                {
                    Success = true,
                    Code = 200,
                    Result = new BaseTaskResultViewModel() { Id = _taskModel.Id }
                };
                return resultResponse;
            }

            //Response Result
            resultResponse = new BaseResultViewModel<BaseTaskResultViewModel>()
            {
                Success = true,
                Code = 400,
                Result = null
            };

            return resultResponse;
        }
    }
}