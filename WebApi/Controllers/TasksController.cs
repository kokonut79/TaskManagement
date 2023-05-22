using System;
using System.Collections.Generic;
using System.Web.Http;
using AppService.DTOs;
using AppService.Implementations;
using Microsoft.Ajax.Utilities;
using WebAPI.Messages;


namespace WebApi.Controllers
{
    public class TasksController : ApiController
    {
        private readonly TasksManagementService _tasksService;

        public TasksController()
        {
            _tasksService = new TasksManagementService();
        }

        [HttpGet]
        [Route("api/tasks")]
        public IHttpActionResult Get()
        {

            return Json(_tasksService.Get());
        }

        [HttpGet]
        [Route("api/tasks/{id}")]
        public IHttpActionResult GetById(int id)
        {
            return Json(_tasksService.GetById(id));
        }

        [HttpPost]
        [Route("api/tasks/Save")]
        public IHttpActionResult Save(TasksDTO taskDto)
        {
            if (!taskDto.Validate())
            {
                return Json(new ResponseMessage
                {
                    Code = 500, Error = "Data is not valid !  "
                });
            }

            ResponseMessage response = new ResponseMessage();
            if (_tasksService.Save(taskDto))
            {
                response.Code = 200;
                response.Body = "Task is saved.";
            }
            else
            {
                response.Code = 500;
                response.Error = "Task was not saved.";
            }

            return Json(response);
        }
       

        [HttpPut]
        [Route("api/tasks/{id}")]
        public IHttpActionResult Edit(int id, TasksDTO taskDto)
        {
            ResponseMessage response = new ResponseMessage();
            if (taskDto.TaskId == id)
            {
                if (!taskDto.Validate())
                {
                    return Json(new ResponseMessage
                    {
                        Code = 500,
                        Error = "Data is not valid !"
                    });
                }

                if (_tasksService.Edit(taskDto))
                {
                    response.Code = 200;
                    response.Body = "Task was edited.";
                }
                else
                {
                    response.Code = 500;
                    response.Body = "Task was not edited.";
                }
            }
                return Json(response);
        }

        [HttpDelete]
        [Route("api/tasks/{id}")]
        public IHttpActionResult Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (_tasksService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Task is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Task is not deleted.";
            }

            return Json(response);
        }
    }
}