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

        public async Task<IActionResult> GetAsignmentById([FromQuery] GetAssignmentByIdRequest request, int assignmentId)
        {
            request = new GetAssignmentByIdRequest(assignmentId);
            var response = await this.mediator.Send(request);            
            return this.Ok(response);
        }
    }
}
