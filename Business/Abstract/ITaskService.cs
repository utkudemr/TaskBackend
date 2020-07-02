using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITaskService
    {
        IDataResult<Task> Add(TaskDto task);
        IDataResult<Task> Update(TaskDto task);
        IDataResult<Task> Remove(int taskId);
        IDataResult<List<Task>> GetTaskList();
        IDataResult<Task> GetTaskById(int taskId);

    }
}
