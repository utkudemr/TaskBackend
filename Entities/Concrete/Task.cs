using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Task:IEntity
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Explanation { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }


    }
}
