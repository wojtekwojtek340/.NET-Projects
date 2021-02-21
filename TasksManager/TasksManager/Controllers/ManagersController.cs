using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
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
        public async Task<IActionResult> GetAllManagers([FromQuery] GetManagersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
    }
}
