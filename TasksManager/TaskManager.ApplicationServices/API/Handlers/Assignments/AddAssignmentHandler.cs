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
    public class AddAssignmentHandler : IRequestHandler<AddAssignmentRequest, AddAssignmentResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddAssignmentHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddAssignmentResponse> Handle(AddAssignmentRequest request, CancellationToken cancellationToken)
        {
            var assignment = mapper.Map<Assignment>(request);
            var command = new AddAssignmentCommand() { Parameter = assignment };
            var assignmentFromDb = await this.commandExecutor.Execute(command);
            return new AddAssignmentResponse()
            {
                Data = mapper.Map<AssignmentDto>(assignmentFromDb)
            };
        }
    }
}
