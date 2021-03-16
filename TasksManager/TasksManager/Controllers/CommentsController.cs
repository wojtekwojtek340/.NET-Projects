using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Comments;

namespace TasksManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ApiControllerBase
    {
        public CommentsController(IMediator mediator, ILogger<CommentsController> logger) : base(mediator)
        {
            logger.LogInformation("We are in comment controller");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllComments([FromQuery] GetAllCommentsRequest request)
        {
            return this.HandleRequest<GetAllCommentsRequest, GetAllCommentsResponse>(request);
        }

        [HttpGet]
        [Route("{CommentId}")]

        public Task<IActionResult> GetCommentById([FromRoute] GetCommentByIdRequest request)
        {
            return this.HandleRequest<GetCommentByIdRequest, GetCommentByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddComment([FromQuery] AddCommentRequest request)
        {
            return this.HandleRequest<AddCommentRequest, AddCommentResponse>(request);
        }

        [HttpDelete]
        [Route("{CommentId}")]
        public Task<IActionResult> DeleteCommentById([FromRoute] DeleteCommentByIdRequest request)
        {
            return this.HandleRequest<DeleteCommentByIdRequest, DeleteCommentByIdResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutCommentById([FromQuery] PutCommentByIdRequest request)
        {
            return this.HandleRequest<PutCommentByIdRequest, PutCommentByIdResponse>(request);
        }
    }
}
