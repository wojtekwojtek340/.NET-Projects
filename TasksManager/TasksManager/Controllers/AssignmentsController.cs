using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Assignments;
using TaskManager.ApplicationServices.Components.OpenWeather;

namespace TasksManager.Controllers
{  
    [ApiController]
    [Route("[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AssignmentsController(IMediator mediator, ILogger<AssignmentsController> logger)
        {
            this.mediator = mediator;
            logger.LogInformation("we are in Books");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAssignments([FromQuery] GetAllAssignmentsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{AssignmentId}")]

        public async Task<IActionResult> GetAsignmentById([FromRoute] GetAssignmentByIdRequest request)
        {
            var response = await this.mediator.Send(request);            
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddAssignment([FromQuery] AddAssignmentRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{AssignmentId}")]
        public async Task<IActionResult> DeleteAssignmentById([FromRoute] DeleteAssignmentByIdRequest request)
        {
            var response = await mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutAssignmentById([FromQuery] PutAssignmentByIdRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
