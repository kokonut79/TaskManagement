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
    public class TasksManagementService
    {
        public List<TasksDTO> Get()
        {
            List<TasksDTO> taskDtos = new List<TasksDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.TasksRepository.Get())
                {
                    taskDtos.Add(new TasksDTO
                    {
                        TaskId = item.TaskId,
                        Title = item.Title,
                        Description = item.Description,
                        Status = item.Status
                    });
                }
            }

            return taskDtos;
        }

        public TasksDTO GetById(int id)
        {
            TasksDTO taskDTO = new TasksDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Tasks task = unitOfWork.TasksRepository.GetByID(id);
                if (task != null)
                {
                    taskDTO = new TasksDTO()
                    {
                        TaskId = task.TaskId,
                        Title = task.Title,
                        Description = task.Description,
                        Status = task.Status
                    };
                }
            }

            return taskDTO;
        }

        public bool Save(TasksDTO taskDto)
        {
            Tasks task = new Tasks()
            {
                TaskId = taskDto.TaskId,
                Title = taskDto.Title,
                Description = taskDto.Description,
                Status = taskDto.Status
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.TasksRepository.Insert(task);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Create(TasksDTO taskDto)
        {
            Tasks task = new Tasks()
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                Status = taskDto.Status
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.TasksRepository.Insert(task);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(TasksDTO taskDto)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Tasks task = unitOfWork.TasksRepository.GetByID(taskDto.TaskId);
                    if (task != null)
                    {
                        task.Title = taskDto.Title;
                        task.Description = taskDto.Description;
                        task.Status = taskDto.Status;

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
                    Tasks task = unitOfWork.TasksRepository.GetByID(id);
                    unitOfWork.TasksRepository.Delete(task);
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
