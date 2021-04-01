using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Employees;

namespace TasksManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ApiControllerBase
    {
        public EmployeesController(IMediator mediator, ILogger<EmployeesController> logger) : base(mediator)
        {
            logger.LogInformation("We are in employee controller");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllEmployes([FromQuery] GetAllEmployeesRequest request)
        {
            return this.HandleRequest<GetAllEmployeesRequest, GetAllEmployeesResponse>(request);
        }

        [HttpGet]
        [Route("{EmployeeId}")]
        public Task<IActionResult> GetEmployeeById([FromRoute] GetEmployeeByIdRequest request)
        {
            return this.HandleRequest<GetEmployeeByIdRequest, GetEmployeeByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
        {
            return this.HandleRequest<AddEmployeeRequest, AddEmployeeResponse>(request);
        }

        [HttpDelete]
        [Route("{EmployeeId}")]
        public Task<IActionResult> DeleteEmployeeById([FromRoute] DeleteEmployeeByIdRequest request)
        {
            return this.HandleRequest<DeleteEmployeeByIdRequest, DeleteEmployeeByIdResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutEmployeeById([FromQuery] PutEmployeeByIdRequest request)
        {
            return this.HandleRequest<PutEmployeeByIdRequest, PutEmployeeByIdResponse>(request);
        }
    }
}
