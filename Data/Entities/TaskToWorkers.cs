using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class TaskToWorkers
    {
        [Key, Column(Order = 0), ForeignKey("Worker")]

        public int WorkerId { get; set; }
        public Workers Worker { get; set; }

        [Key, Column(Order = 1), ForeignKey("Tasks")]
        public int TaskId { get; set; }
        public Tasks Tasks { get; set; }

    }
}
