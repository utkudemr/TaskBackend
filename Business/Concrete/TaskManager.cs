using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class TaskManager : ITaskService
    {
        private  ITaskDal _taskDal;
        IHttpContextAccessor _httpContextAccessor;
        public TaskManager(ITaskDal taskDal, IHttpContextAccessor httpContextAccessor)
        {
            _taskDal = taskDal;
            _httpContextAccessor = httpContextAccessor;
        }
        [ValidationAspect(typeof(TaskValidator), Priority = 1)]
        public IDataResult<Task> Add(TaskDto task)
        {
            var newTask = new Task
            {
                EndDate = GetEndDate(task),
                CreateDate = GetStartDate(task),
                Explanation = task.Explanation,
                TaskName = task.TaskName,
            };

            newTask.UserId = GetUserId();
            _taskDal.Add(newTask);
            return new SuccessDataResult<Task>(newTask, Messages.TaskAdded);
        }

        private DateTime GetEndDate(TaskDto task)
        {
            var date = DateTime.Parse(task.EndDate);
            return date;
        }

        private int GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.Where(a => a.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Select(a=>a.Value).FirstOrDefault();
            return int.Parse(userId); 
        }

   
        private DateTime GetStartDate(TaskDto task)
        {
            var datetime = new DateTime();
            if(task.StartDate==null)
            {
                datetime = DateTime.Now;
            }
            else
            {
                datetime = DateTime.Parse(task.StartDate);
            }
            return datetime;
        }

       

        public IDataResult<List<Task>> GetTaskList()
        {
            var list= ExpiredTask(_taskDal.GetList(a=>a.Status==true));
           
            if(list.Count==0)
            {
                return new SuccessDataResult<List<Task>>(list, Messages.TaskListEmpty);
            }
            return new SuccessDataResult<List<Task>>(list, Messages.TaskList);
        }

        private List<Task> ExpiredTask(List<Task> list)
        {
            foreach (var item in list)
            {

                var dateDif = (item.EndDate - DateTime.Now).Days;
                if (dateDif < 0)
                {
                    item.Status = false;
                }
                item.CreateDate = item.CreateDate.Date;
                item.EndDate=item.EndDate.Date;
            }
            return list;
        }

        public IDataResult<Task> Remove(int taskId)
        {
            var response = GetTaskById(taskId);
            if (response == null)
            {
                return new ErrorDataResult<Task>(Messages.TaskNotExists);
            }
            response.Data.Status = false;
            _taskDal.Delete(response.Data);
            return new SuccessDataResult<Task>(response.Data,Messages.TaskDeleted);
        }
        [ValidationAspect(typeof(TaskValidator), Priority = 1)]
        public IDataResult<Task> Update(TaskDto task)
        {
            var updatetask = _taskDal.Get(a=>a.Id==task.Id && a.Status==true);
            if(updatetask==null)
            {
                return new ErrorDataResult<Task>(Messages.TaskNotExists);
            }
            updatetask.CreateDate = GetStartDate(task);
            updatetask.Explanation = task.Explanation;
            updatetask.TaskName = task.TaskName;
            updatetask.EndDate = GetEndDate(task);
            _taskDal.Update(updatetask);
            return new SuccessDataResult<Task>(updatetask, Messages.TaskUpdated);
        }

        public IDataResult<Task> GetTaskById(int taskId)
        {
            var task= _taskDal.Get(a => a.Id == taskId && a.Status==true);
            if(task==null)
            {
                return new ErrorDataResult<Task>(Messages.TaskNotExists);
            }
            return new SuccessDataResult<Task>(task);
        }
    }
}
