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
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public DateTime? StartedWorkingOn { get; set; }
        public decimal? Salary { get; set; }
        public int? CompanyId { get; set; }
        public Companies Company { get; set; }
    }
}
