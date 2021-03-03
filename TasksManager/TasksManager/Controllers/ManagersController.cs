using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Managers;
using TaskManager.DataAccess;
using TaskManager.DataAccess.Entities;

namespace TasksManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagersController : ControllerBase
    {
        private readonly IMediator mediator;

        public ManagersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllManagers([FromQuery] GetAllManagersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{managerId}")]

        public async Task<IActionResult> GetManagerById([FromRoute] int managerId)
        {
            var request = new GetManagerByIdRequest
            {
                ManagerId = managerId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddManager([FromQuery] AddManagerRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{managerId}")]

        public async Task<IActionResult> DeleteManagerById([FromRoute] int managerId)
        {
            var request = new DeleteManagerByIdRequest
            {
                ManagerId = managerId
            };
            var response = await mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutManagerById([FromQuery] PutManagerByIdRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
