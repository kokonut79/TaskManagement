using System;
using System.Web.Http;
using AppService.DTOs;
using AppService.Implementations;
using WebAPI.Messages;

namespace WebApi.Controllers
{
    [Authorize]
    public class WorkersController : ApiController
    {
        private readonly WorkersManagementService _workersManagementService;

        public WorkersController()
        {
            _workersManagementService = new WorkersManagementService();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/workers")]
        public IHttpActionResult Get()
        {
            return Json(_workersManagementService.Get());
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("api/workers/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Json(_workersManagementService.GetById(id));
        }
        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpPut]
        [Route("api/workers/Edit")]
        public IHttpActionResult Edit( [FromBody] WorkerDTO workerDto)
        {
            ResponseMessage response = new ResponseMessage();
           
            
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
            
            return Json(response);
        }

        [AllowAnonymous]
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