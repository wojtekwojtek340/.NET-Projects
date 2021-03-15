using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Employees;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Employees;
using TaskManager.DataAccess.CQRS.Queries.Employees;

namespace TaskManager.ApplicationServices.API.Handlers.Employees
{
    public class DeleteEmployeeByIdHandler : IRequestHandler<DeleteEmployeeByIdRequest, DeleteEmployeeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteEmployeeByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteEmployeeByIdResponse> Handle(DeleteEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEmployeeQuery()
            {
                Id = request.EmployeeId
            };

            var employee = await queryExecutor.Execute(query);

            if(employee == null)
            {
                return new DeleteEmployeeByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteEmployeeCommand() { Parameter = employee };
            var deletedEmployee = await commandExecutor.Execute(command);
            return new DeleteEmployeeByIdResponse
            {
                Data = deletedEmployee
            };
        }
    }
}
