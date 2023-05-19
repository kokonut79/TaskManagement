using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BaseEntity
    {
        public DateTime  CreatedOn { get; set; }
        public DateTime UpdatedOn { get;set; }

    }
}
