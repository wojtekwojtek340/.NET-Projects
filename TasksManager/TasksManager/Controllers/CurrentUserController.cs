using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.CurrentUser;

namespace TasksManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CurrentUserController : ApiControllerBase
    {
        public CurrentUserController(IMediator mediator, ILogger<CurrentUserController> logger) : base(mediator)
        {
            logger.LogInformation("We are in current user controller");
        }

        [HttpGet]
        [Route("{Me}")]
        public Task<IActionResult> GetEmployeeById([FromRoute] GetCurrentUserRequest request)
        {
            return this.HandleRequest<GetCurrentUserRequest, GetCurrentUserResponse>(request);
        }
    }
}
