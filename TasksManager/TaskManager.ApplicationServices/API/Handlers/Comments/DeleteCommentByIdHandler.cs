using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Comments;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Comments;

namespace TaskManager.ApplicationServices.API.Handlers.Comments
{
    public class DeleteCommentByIdHandler : IRequestHandler<DeleteCommentByIdRequest, DeleteCommentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteCommentByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteCommentByIdResponse> Handle(DeleteCommentByIdRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteCommentCommand() { Parameter = request.CommentId };
            var deletedComment = await commandExecutor.Execute(command);
            return new DeleteCommentByIdResponse
            {
                Data = deletedComment
            };
        }
    }
}
