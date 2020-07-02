using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class TaskValidator : AbstractValidator<TaskDto>
    {
        public TaskValidator()
        {
            RuleFor(p => p.Explanation).NotEmpty();
            RuleFor(p => p.TaskName).NotEmpty();
            RuleFor(p => p.StartDate).NotEmpty();
            RuleFor(p => p.EndDate).NotEmpty();
            RuleFor(p => p).Must(StartEndDate).WithMessage("Tarih hatası");
        }

        private bool StartEndDate(TaskDto arg)
        {
            if (arg.EndDate == null || arg.StartDate == null)
            {
                return false;
            }
                
            var endDate = DateTime.Parse(arg.EndDate);
            var startDate = DateTime.Parse(arg.StartDate);

            var datetime = (endDate - startDate).Days;
            if(datetime<0 || endDate<DateTime.Now.Date)
            {
                return false;
            }
            return true;
        }

       
    }
}
