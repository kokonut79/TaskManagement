using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BaseEntity
    {

        [Key]
        public int Id { get; set; }        
        public DateTime  CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get;set; }

    }
}
