using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Companies;
using TaskManager.DataAccess;
using TaskManager.DataAccess.Entities;

namespace TasksManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ApiControllerBase
    {
        public CompaniesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllCompanies([FromQuery] GetAllCompaniesRequest request)
        {
            return this.HandleRequest<GetAllCompaniesRequest, GetAllCompaniesResponse>(request);
        }

        [HttpGet]
        [Route("{CompanyId}")]

        public Task<IActionResult> GetCompanyById([FromRoute] GetCompanyByIdRequest request)
        {
            return this.HandleRequest<GetCompanyByIdRequest, GetCompanyByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddCompany([FromQuery] AddCompanyRequest request)
        {
            return this.HandleRequest<AddCompanyRequest, AddCompanyResponse>(request);
        }

        [HttpDelete]
        [Route("{CompanyId}")]

        public Task<IActionResult> DeleteCompanyById([FromRoute] DeleteCompanyByIdRequest request)
        {
            return this.HandleRequest<DeleteCompanyByIdRequest, DeleteCompanyByIdResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutCompanyById([FromQuery] PutCompanyByIdRequest request)
        {
            return this.HandleRequest<PutCompanyByIdRequest, PutCompanyByIdResponse>(request);
        }
    }
}
