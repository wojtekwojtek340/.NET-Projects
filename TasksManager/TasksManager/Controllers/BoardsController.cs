using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Boards;

namespace TasksManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardsController : ControllerBase
    {
        private readonly IMediator mediator;

        public BoardsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]        
        public async Task<IActionResult> GetAllBoards([FromQuery] GetAllBoardsRequest request)
        {
            var response = await mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBoard([FromQuery] AddBoardRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
