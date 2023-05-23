using System;
using System.Web.Http;
using AppService.DTOs;
using AppService.Implementations;
using WebAPI.Messages;

namespace WebApi.Controllers
{
    public class CompaniesController : ApiController
    {
        private readonly CompaniesManagementService _companiesManagementService;

        public CompaniesController()
        {
            _companiesManagementService = new CompaniesManagementService();
        }

        [HttpGet]
        [Route("api/companies")]
        public IHttpActionResult Get()
        {

            return Json(_companiesManagementService.Get());
        }

        [HttpGet]
        [Route("api/companies/{id}")]
        public IHttpActionResult GetById(int id)
        {
            return Json(_companiesManagementService.GetById(id));
        }

        [HttpPost]
        [Route("api/companies/Save")]
        public IHttpActionResult Save([FromBody]CompanyDTO companyDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResponseMessage
                {
                    Code = 500,
                    Error = "Data is not valid !  "
                });
            }

            ResponseMessage response = new ResponseMessage();
            if (_companiesManagementService.Save(companyDto))
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
        [Route("api/companies/Edit/{id}")]
        public IHttpActionResult Edit(int id, [FromBody] CompanyDTO companyDto)
        {
            ResponseMessage response = new ResponseMessage();
            if (companyDto.CompanyId == id)
            {
                if (!ModelState.IsValid)
                {
                    return Json(new ResponseMessage
                    {
                        Code = 500,
                        Error = "Data is not valid !"
                    });
                }

                if (_companiesManagementService.Edit(companyDto))
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
        [Route("api/companies/{id}")]
        public IHttpActionResult Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (_companiesManagementService.Delete(id))
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