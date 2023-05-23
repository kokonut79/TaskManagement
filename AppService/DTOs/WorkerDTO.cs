using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace AppService.DTOs
{
    public class WorkerDTO
    {
        public int WorkerId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }

        public List<Tasks> AssignedTasks { get; set; }
        public List<Companies> CompanyName { get; set; }

    }
}
