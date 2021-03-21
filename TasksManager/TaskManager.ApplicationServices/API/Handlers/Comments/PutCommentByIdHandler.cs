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
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Comments;
using TaskManager.DataAccess.CQRS.Queries.Assignments;
using TaskManager.DataAccess.CQRS.Queries.Comments;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Comments
{
    public class PutCommentByIdHandler : IRequestHandler<PutCommentByIdRequest, PutCommentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutCommentByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<PutCommentByIdResponse> Handle(PutCommentByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticatorRole == AppRole.Employee)
            {
                return new PutCommentByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetAssignmentQuery()
            {
                Id = request.AssignmentId
            };
            var query2 = new GetCommentQuery()
            {
                Id = request.Id
            };

            var comment = await queryExecutor.Execute(query2);
            var assignment = await queryExecutor.Execute(query);

            if (assignment == null || comment == null)
            {
                return new PutCommentByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var updatecomment = mapper.Map<Comment>(request);
            var command = new PutCommentCommand
            {
                Parameter = updatecomment
            };
            var updatedComment = await commandExecutor.Execute(command);
            var response = mapper.Map<CommentDto>(updatedComment);
            return new PutCommentByIdResponse
            {
                Data = response
            };
        }
    }
}
