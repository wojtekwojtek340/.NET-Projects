using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Employees;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Employees;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Employees
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeRequest, AddEmployeeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddEmployeeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddEmployeeResponse> Handle(AddEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = mapper.Map<Employee>(request);
            var command = new AddEmployeeCommand() { Parameter = employee };
            var employeeFromDb = await commandExecutor.Execute(command);
            return new AddEmployeeResponse()
            {
                Data = mapper.Map<EmployeesDto>(employeeFromDb)
            };
        }
    }
}
