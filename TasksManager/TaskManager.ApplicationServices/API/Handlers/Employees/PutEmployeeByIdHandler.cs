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
    public class PutEmployeeByIdHandler : IRequestHandler<PutEmployeeByIdRequest, PutEmployeeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public PutEmployeeByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<PutEmployeeByIdResponse> Handle(PutEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var employee = mapper.Map<Employee>(request);
            var command = new PutEmployeeCommand
            {
                Parameter = employee
            };
            var updatedEmployee = await commandExecutor.Execute(command);
            var response = mapper.Map<EmployeeDto>(updatedEmployee);
            return new PutEmployeeByIdResponse
            {
                Data = response
            };

        }
    }
}
