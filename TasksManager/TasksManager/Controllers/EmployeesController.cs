using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Employees;

namespace TasksManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllEmployes([FromQuery] GetAllEmployeesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{employeeId}")]

        public async Task<IActionResult> GetEmployeeById([FromRoute] int employeeId)
        {
            var request = new GetEmployeeByIdRequest
            {
                EmployeeId = employeeId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddEmployee([FromQuery] AddEmployeeRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{EmployeeId}")]
        public async Task<IActionResult> DeleteEmployeeById([FromRoute] DeleteEmployeeByIdRequest request)
        {
            var response = await mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutEmployeeById([FromQuery] PutEmployeeByIdRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
