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
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Comments
{
    public class AddCommentHandler : IRequestHandler<AddCommentRequest, AddCommentResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public AddCommentHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddCommentResponse> Handle(AddCommentRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticatorRole == AppRole.Employee)
            {
                return new AddCommentResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetAssignmentQuery()
            {
                Id = request.AssignmentId
            };
            var assignment = await queryExecutor.Execute(query);
            
            if(assignment == null)
            {
                return new AddCommentResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var comment = mapper.Map<Comment>(request);
            var command = new AddCommentCommand() { Parameter = comment };
            var commentFromDb = await commandExecutor.Execute(command);
            return new AddCommentResponse()
            {
                Data = mapper.Map<CommentDto>(commentFromDb)
            };
        }
    }
}
