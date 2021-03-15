using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Assignments;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Assignments;
using TaskManager.DataAccess.CQRS.Queries.Assignments;

namespace TaskManager.ApplicationServices.API.Handlers.Assignments
{
    public class DeleteAssignmentByIdHandler : IRequestHandler<DeleteAssignmentByIdRequest, DeleteAssignmentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteAssignmentByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteAssignmentByIdResponse> Handle(DeleteAssignmentByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAssignmentQuery()
            {
                Id = request.AssignmentId
            };
            var assignment = await queryExecutor.Execute(query);

            if(assignment == null)
            {
                return new DeleteAssignmentByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteAssignmentCommand() { Parameter = assignment };
            var deletedAssignment = await commandExecutor.Execute(command);
            return new DeleteAssignmentByIdResponse
            {
                Data = deletedAssignment
            };
        }
    }
}
