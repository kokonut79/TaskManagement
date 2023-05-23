using AppService.DTOs;
using Data.Entities;
using Repositories.Implementaions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Implementations
{
    public class WorkersManagementService
    {
        public List<WorkerDTO> Get()
        {
            List<WorkerDTO> workerDtos = new List<WorkerDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.WorkersRepository.Get())
                {
                    workerDtos.Add(new WorkerDTO
                    {
                        // WorkerId = item.WorkerId,
                        First_Name = item.First_Name,
                        Last_Name = item.Last_Name,
                        Email = item.Email,


                    });
                }
            }

            return workerDtos;
        }

        public WorkerDTO GetById(int id)
        {
            WorkerDTO workerDTO = new WorkerDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Workers worker = unitOfWork.WorkersRepository.GetByID(id);
                if (worker != null)
                {
                    workerDTO = new WorkerDTO()
                    {
                        // WorkerId = worker.WorkerId,
                        First_Name = worker.First_Name,
                        Last_Name = worker.Last_Name,
                        Email = worker.Email,

                    };
                }
            }

            return workerDTO;
        }

        public bool Save(WorkerDTO workerDto)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (workerDto == null)
                    {
                        return false;
                    }
                    var worker = new Workers
                    {
                        WorkerId = workerDto.WorkerId,
                        First_Name = workerDto.First_Name,
                        Last_Name = workerDto.Last_Name,
                        Email = workerDto.Email,
                        Age = workerDto.Age,
                        StartedWorkingOn = workerDto.StartedWorkingOn,
                        Salary = workerDto.Salary,
                        CompanyId = workerDto.CompanyId // Assigning the CompanyId

                    };
                    unitOfWork.WorkersRepository.Insert(worker);
                    unitOfWork.Save();

                    return true;
                }
            }
            catch
            {
                return false;
            }

        }


        public bool Edit(WorkerDTO workerDto)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Workers worker = unitOfWork.WorkersRepository.GetByID(workerDto.WorkerId);
                    if (worker != null)
                    {
                        worker.First_Name = workerDto.First_Name;
                        worker.Last_Name = workerDto.Last_Name;
                        worker.Email = workerDto.Email;


                        unitOfWork.Save();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Workers worker = unitOfWork.WorkersRepository.GetByID(id);
                    unitOfWork.WorkersRepository.Delete(worker);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
