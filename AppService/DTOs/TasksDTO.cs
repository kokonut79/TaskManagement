using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace AppService.DTOs
{
    public class TasksDTO
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public int? WorkerId { get; set; }
        public Workers Worker { get; set; }

        public bool Validate()
        {
            return !String.IsNullOrEmpty(Title);
        }
    }
}
