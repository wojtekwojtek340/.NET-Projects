using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Users;

namespace TasksManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator, ILogger<UsersController> logger) : base(mediator)
        {
            logger.LogInformation("We are in current user controller");
        }

        [HttpGet]
        [Route("{Me}")]
        public Task<IActionResult> GetCurrentUser([FromRoute] GetUserRequest request)
        {
            return this.HandleRequest<GetUserRequest, GetUserResponse>(request);
        }
    }
}
