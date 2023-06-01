using AppService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CompaniesVM
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public List<Data.Entities.Workers> Workers { get; set; }

        public CompaniesVM() { }

        public CompaniesVM(CompanyDTO companyDTO) { 
            CompanyId= companyDTO.CompanyId;
            Name= companyDTO.Name;
            Email= companyDTO.Email;
            Description= companyDTO.Description;
            Workers = companyDTO.Workers;

        }
    }
}