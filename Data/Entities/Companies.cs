using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Companies : BaseEntity   
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Revenue { get; set; }
        public string Description { get; set; }

    
    }
}
