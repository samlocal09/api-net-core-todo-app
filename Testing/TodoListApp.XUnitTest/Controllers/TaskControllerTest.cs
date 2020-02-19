using AngularNetCoreIMS.WebApi.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using TodoListApp.Service.Common.Interfaces;
using TodoListApp.Service.Common.ViewModels;
using TodoListApp.Service.Common.ViewModels.MasterData;
using Xunit;

namespace TodoListApp.XUnitTest.Controllers
{
	public class TaskControllerTest
	{
		private TasksController controller;
		private Mock<ITaskService> taskServiceMock;

		private BaseResultsViewModel<TaskViewModel> items;

		public TaskControllerTest()
		{
			taskServiceMock = new Mock<ITaskService>();

			items = new BaseResultsViewModel<TaskViewModel>()
			{
				Code = 200,
				Success = true,
				Result = new List<TaskViewModel>()
				{
					new TaskViewModel
					{
						Id = new Guid("27e822b6-fa17-459b-7ab1-08d7327ca61d"),
						Name = "Task 1",
						Description = "Description 1",
						StartDateAt = DateTime.Now,
						FinishedDateAt = null,
						ThumbTask = null,
						Remark = "remark 1",
						EstimationTime = 2,
						StatusKey = 3,
						StatusDescription = "Completed"
					} ,
					new TaskViewModel
					{
						Id = new Guid("24820678-f84e-436b-35ed-08d73818e639"),
						Name = "Task 2",
						Description = "Description 2",
						StartDateAt = DateTime.Now.AddDays(2),
						FinishedDateAt = null,
						ThumbTask = null,
						Remark = "remark 2",
						EstimationTime = 5,
						StatusKey = 3,
						StatusDescription = "Completed"
					} ,
				}
			};

			controller = new TasksController(taskServiceMock.Object);
		}


		[Fact]
		public void ShouldReturnListTask()
		{
			// arrange
			taskServiceMock.Setup(p => p.GetTaskṣ̣̣()).Returns(items);

			// act
			var result = controller.ListTask();

			// assert
			Assert.NotNull(result);
		}
	}
}
