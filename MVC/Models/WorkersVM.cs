using AppService.DTOs;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class WorkersVM
    {
        [Key]
        public int WorkerId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public int? CompanyId { get; set; }

        public List<Data.Entities.Tasks> Tasks { get; set; }

        public WorkersVM() { }

        public WorkersVM(WorkerDTO workerDTO )
        {
            WorkerId = workerDTO.WorkerId;
            First_Name = workerDTO.First_Name;
            Last_Name = workerDTO.Last_Name;
            Email = workerDTO.Email;
            CompanyId = workerDTO.CompanyId;
            Tasks = workerDTO.AssignedTasks;
        }
    }
}