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
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Assignments
{
    public class PutAssignmentByIdHandler : IRequestHandler<PutAssignmentByIdRequest, PutAssignmentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public PutAssignmentByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<PutAssignmentByIdResponse> Handle(PutAssignmentByIdRequest request, CancellationToken cancellationToken)
        {
            var assignment = mapper.Map<Assignment>(request);
            var command = new PutAssignmentCommand
            {
                Parameter = assignment
            };
            var updatedAssignment = await commandExecutor.Execute(command);
            var response = mapper.Map<AssignmentDto>(updatedAssignment);

            return new PutAssignmentByIdResponse
            {
                Data = response  
            };
        }
    }
}
