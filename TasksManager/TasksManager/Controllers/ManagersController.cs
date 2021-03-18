using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Managers;
using TaskManager.DataAccess;
using TaskManager.DataAccess.Entities;

namespace TasksManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ManagersController : ApiControllerBase
    {
        public ManagersController(IMediator mediator, ILogger<ManagersController> logger) : base(mediator)
        {
            logger.LogInformation("We are in manager controller");
        }
        
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllManagers([FromQuery] GetAllManagersRequest request)
        {
            return this.HandleRequest<GetAllManagersRequest, GetAllManagersResponse>(request);
        }

        [HttpGet]
        [Route("{ManagerId}")]
        public Task<IActionResult> GetManagerById([FromRoute] GetManagerByIdRequest request)
        {
            return this.HandleRequest<GetManagerByIdRequest, GetManagerByIdResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddManager([FromQuery] AddManagerRequest request)
        {
            return this.HandleRequest<AddManagerRequest, AddManagerResponse>(request);
        }

        [HttpDelete]
        [Route("{ManagerId}")]

        public Task<IActionResult> DeleteManagerById([FromRoute] DeleteManagerByIdRequest request)
        {
            return this.HandleRequest<DeleteManagerByIdRequest, DeleteManagerByIdResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutManagerById([FromQuery] PutManagerByIdRequest request)
        {
            return this.HandleRequest<PutManagerByIdRequest, PutManagerByIdResponse>(request);
        }
    }
}
