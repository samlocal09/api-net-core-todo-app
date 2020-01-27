using Microsoft.AspNetCore.Mvc;
using System;
using TodoListApp.Service.Common.Interfaces;
using TodoListApp.Service.Common.ViewModels.MasterData;

namespace AngularNetCoreIMS.WebApi.Controllers
{
    [Route("api/v1/tasks")]
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("{taskId}")]
        public IActionResult GetDetailById(Guid taskId)
        {
            var result = _taskService.GetTaskById(taskId);
            if (result.Success)
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("")]
        public IActionResult ListTask()
        {
            var results = _taskService.GetTaskṣ̣̣();
            if (results.Success)
            {
                return Ok(results);
            }
            return NoContent();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody]TaskViewModel model)
        {
            var result = _taskService.Create(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        [Route("")]
        public IActionResult Update([FromBody]TaskViewModel model)
        {
            var result = _taskService.Update(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            Guid checkGuidOutPut = Guid.Empty;
            var isValidParse = Guid.TryParse(id, out checkGuidOutPut);
            if(isValidParse)
            { 
                var result = _taskService.Delete(checkGuidOutPut);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return NotFound();
        }
    }
}