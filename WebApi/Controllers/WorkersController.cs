using System;
using System.Web.Http;
using AppService.DTOs;
using AppService.Implementations;
using WebAPI.Messages;

namespace WebApi.Controllers
{
    public class WorkersController : ApiController
    {
        private readonly WorkersManagementService _workersManagementService;

        public WorkersController()
        {
            _workersManagementService = new WorkersManagementService();
        }

        [HttpGet]
        [Route("api/workers")]
        public IHttpActionResult Get()
        {
            return Json(_workersManagementService.Get());
        }

        [HttpGet]
        [Route("api/workers/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Json(_workersManagementService.GetById(id));
        }

        [HttpPost]
        [Route("api/workers/Save")]
        public IHttpActionResult Save([FromBody] WorkerDTO workerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseMessage response = new ResponseMessage();

            if (_workersManagementService.Save(workerDto))
            {
                response.Code = 200;
                response.Body = "Worker is saved.";
            }
            else
            {
                response.Code = 500;
                response.Error = "Worker was not saved.";
            }

            return Json(response);
        }


        [HttpPut]
        [Route("api/workers/Edit/{id}")]
        public IHttpActionResult Edit(int id, [FromBody] WorkerDTO workerDto)
        {
            ResponseMessage response = new ResponseMessage();
            if (workerDto.WorkerId == id)
            {
                if (!ModelState.IsValid)
                {
                    return Json(new ResponseMessage
                    {
                        Code = 500,
                        Error = "Data is not valid !"
                    });
                }

                if (_workersManagementService.Edit(workerDto))
                {
                    response.Code = 200;
                    response.Body = "Worker was edited.";
                }
                else
                {
                    response.Code = 500;
                    response.Body = "Worker was not edited.";
                }
            }
            return Json(response);
        }

        [HttpDelete]
        [Route("api/workers/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (_workersManagementService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Worker is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Worker is not deleted.";
            }

            return Json(response);
        }
    }
}