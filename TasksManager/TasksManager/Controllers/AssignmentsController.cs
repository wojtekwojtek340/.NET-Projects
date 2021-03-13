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
    public class AssignmentsController : ApiControllerBase
    {
        public AssignmentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllAssignments([FromQuery] GetAllAssignmentsRequest request)
        {
            return this.HandleRequest<GetAllAssignmentsRequest, GetAllAssignmentsResponse>(request);
        }

        [HttpGet]
        [Route("{AssignmentId}")]

        public Task<IActionResult> GetAsignmentById([FromRoute] GetAssignmentByIdRequest request)
        {
            return this.HandleRequest<GetAssignmentByIdRequest, GetAssignmentByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddAssignment([FromQuery] AddAssignmentRequest request)
        {
            return this.HandleRequest<AddAssignmentRequest, AddAssignmentResponse>(request);
        }

        [HttpDelete]
        [Route("{AssignmentId}")]
        public Task<IActionResult> DeleteAssignmentById([FromRoute] DeleteAssignmentByIdRequest request)
        {
            return this.HandleRequest<DeleteAssignmentByIdRequest, DeleteAssignmentByIdResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutAssignmentById([FromQuery] PutAssignmentByIdRequest request)
        {
            return this.HandleRequest<PutAssignmentByIdRequest, PutAssignmentByIdResponse>(request);
        }
    }
}
