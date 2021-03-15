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
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Employees;
using TaskManager.DataAccess.CQRS.Queries.Companies;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Employees
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeRequest, AddEmployeeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public AddEmployeeHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddEmployeeResponse> Handle(AddEmployeeRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCompanyQuery()
            {
                Id = request.CompanyId
            };
            var company = await queryExecutor.Execute(query);

            if (company == null)
            {
                return new AddEmployeeResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var employee = mapper.Map<Employee>(request);
            var command = new AddEmployeeCommand() { Parameter = employee };
            var employeeFromDb = await commandExecutor.Execute(command);
            employeeFromDb.Company.EmployeesList = null;
            employeeFromDb.Company.Manager = null;
            return new AddEmployeeResponse()
            {
                Data = mapper.Map<EmployeeDto>(employeeFromDb)
            };
        }
    }
}
