using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class TaskDto: IDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public int TaskType { get; set; }
       
        public string Explanation { get; set; }

        public bool Status { get; set; }
         public string StartDate { get; set; }
         public string EndDate { get; set; }
    }
}
