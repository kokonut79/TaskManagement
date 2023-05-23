using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;


namespace Data.Entities
{
    public class Workers : BaseEntity
    {
        [Key]
        public int WorkerId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime StartedWorkingOn { get; set; }
        public decimal Salary { get; set; }

        public int TaskId { get; set; }
        public virtual Tasks Tasks { get; set; }

        public int? CompanyId { get; set; }
        public virtual Companies Company { get; set; }

        public virtual List<Tasks> AssignedTasks { get; set; }

    }
}
