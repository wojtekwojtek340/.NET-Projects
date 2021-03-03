using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Comments;

namespace TasksManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CommentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllComments([FromQuery] GetAllCommentsRequest request)
        {
            var response = await mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{commentId}")]

        public async Task<IActionResult> GetCommentById([FromRoute] int commentId)
        {
            var request = new GetCommentByIdRequest
            {
                CommentId = commentId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddComment([FromQuery] AddCommentRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{commentId}")]

        public async Task<IActionResult> DeleteCommentById([FromRoute] int commentId)
        {
            var request = new DeleteCommentByIdRequest
            {
                CommentId = commentId
            };
            var response = await mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutCommentById([FromQuery] PutCommentByIdRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
