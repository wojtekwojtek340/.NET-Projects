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
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CompaniesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCompanies([FromQuery] GetAllCompaniesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCompany([FromQuery] AddCompanyRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
