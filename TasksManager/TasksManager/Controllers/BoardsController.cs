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
    public class BoardsController : ApiControllerBase
    {
        public BoardsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]        
        public Task<IActionResult> GetAllBoards([FromQuery] GetAllBoardsRequest request)
        {
            return this.HandleRequest<GetAllBoardsRequest, GetAllBoardsResponse>(request);
        }

        [HttpGet]
        [Route("{BoardId}")]

        public Task<IActionResult> GetBoardById([FromRoute] GetBoardByIdRequest request)
        {
            return this.HandleRequest<GetBoardByIdRequest, GetBoardByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddBoard([FromQuery] AddBoardRequest request)
        {
            return this.HandleRequest<AddBoardRequest, AddBoardResponse>(request);
        }

        [HttpDelete]
        [Route("{BoardId}")]

        public Task<IActionResult> DeleteBoardById([FromRoute] DeleteBoardByIdRequest request)
        {
            return this.HandleRequest<DeleteBoardByIdRequest, DeleteBoardByIdResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutBoardById([FromQuery] PutBoardByIdRequest request)
        {
            return this.HandleRequest<PutBoardByIdRequest, PutBoardByIdResponse>(request);
        }

    }
}
