using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Comments;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Comments;
using TaskManager.DataAccess.CQRS.Queries.Comments;

namespace TaskManager.ApplicationServices.API.Handlers.Comments
{
    public class DeleteCommentByIdHandler : IRequestHandler<DeleteCommentByIdRequest, DeleteCommentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteCommentByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteCommentByIdResponse> Handle(DeleteCommentByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticatorRole == AppRole.Employee)
            {
                return new DeleteCommentByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetCommentQuery()
            {
                Id = request.CommentId
            };
            var comment = await queryExecutor.Execute(query);

            if(comment == null)
            {
                return new DeleteCommentByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteCommentCommand() { Parameter = comment };
            var deletedComment = await commandExecutor.Execute(command);
            return new DeleteCommentByIdResponse
            {
                Data = deletedComment
            };
        }
    }
}
