using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Assignments;

namespace TasksManager.Controllers
{  
    [ApiController]
    [Route("[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AssignmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAssignments([FromQuery] GetAllAssignmentsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{assignmentId}")]

        public async Task<IActionResult> GetAsignmentById([FromRoute] int assignmentId)
        {
            var request = new GetAssignmentByIdRequest
            {
                AssignmentId = assignmentId
            };
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
    }
}
