using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Assignments;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Assignments;

namespace TaskManager.ApplicationServices.API.Handlers.Assignments
{
    public class DeleteAssignmentByIdHandler : IRequestHandler<DeleteAssignmentByIdRequest, DeleteAssignmentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteAssignmentByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteAssignmentByIdResponse> Handle(DeleteAssignmentByIdRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteAssignmentCommand() { Parameter = request.AssignmentId };
            var deletedAssignment = await commandExecutor.Execute(command);
            return new DeleteAssignmentByIdResponse
            {
                Data = deletedAssignment
            };
        }
    }
}
