using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Employees;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Employees;

namespace TaskManager.ApplicationServices.API.Handlers.Employees
{
    public class DeleteEmployeeByIdHandler : IRequestHandler<DeleteEmployeeByIdRequest, DeleteEmployeeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteEmployeeByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteEmployeeByIdResponse> Handle(DeleteEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteEmployeeCommand() { Parameter = request.EmployeeId };
            var deletedEmployee = await commandExecutor.Execute(command);
            return new DeleteEmployeeByIdResponse
            {
                Data = deletedEmployee
            };
        }
    }
}
