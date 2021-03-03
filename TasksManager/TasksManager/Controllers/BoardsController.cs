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

        [HttpGet]
        [Route("{boardId}")]

        public async Task<IActionResult> GetBoardById([FromRoute] int boardId)
        {
            var request = new GetBoardByIdRequest
            {
                BoardId = boardId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBoard([FromQuery] AddBoardRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{boardId}")]

        public async Task<IActionResult> DeleteBoardById([FromRoute] int boardId)
        {
            var request = new DeleteBoardByIdRequest
            {
                BoardId = boardId
            };
            var response = await mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutBoardById([FromQuery] PutBoardByIdRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

    }
}
