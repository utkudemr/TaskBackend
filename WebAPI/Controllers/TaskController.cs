using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskManager;

        public TaskController(ITaskService taskManager)
        {
            _taskManager = taskManager;
        }

        [HttpGet("getlist")]
        public ActionResult GetList()
        {
            var list = _taskManager.GetTaskList();
            return Ok(list);
        }


        [Route("get/{id}")]
        public ActionResult GetById(int id)
        {
            var response = _taskManager.GetTaskById(id);
            return Ok(response);
        }

   
        [HttpPost("add")]
        public ActionResult Add([FromBody] TaskDto task)
        {
            var response = _taskManager.Add(task);
            return Ok(response);
        }


        [HttpPut("update")]
        public ActionResult Update([FromBody] TaskDto task)
        {
            var response = _taskManager.Update(task);
            return Ok(response);
        }


        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var response = _taskManager.Remove(id);
            return Ok(response);
        }
    }
}
