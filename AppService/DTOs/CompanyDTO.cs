using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public List<Workers> Workers { get; set; }
    }
}
