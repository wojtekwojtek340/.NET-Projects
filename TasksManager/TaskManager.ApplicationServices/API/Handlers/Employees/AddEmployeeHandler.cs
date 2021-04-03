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
using TaskManager.ApplicationServices.Components.Authorization;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Boards;
using TaskManager.DataAccess.CQRS.Commands.Employees;
using TaskManager.DataAccess.CQRS.Queries;
using TaskManager.DataAccess.CQRS.Queries.Companies;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Employees
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeRequest, AddEmployeeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHasher passwordHasher;

        public AddEmployeeHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IPasswordHasher passwordHasher)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.passwordHasher = passwordHasher;
        }

        public async Task<AddEmployeeResponse> Handle(AddEmployeeRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticatorRole == AppRole.Employee)
            {
                return new AddEmployeeResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var employeeQuery = new GetUserQuery<Employee>()
            {
                Login = request.Login
            };
            var availableManager = await queryExecutor.Execute(employeeQuery);

            if (availableManager != null)
            {
                return new AddEmployeeResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }

            var query = new GetCompanyQuery()
            {
                Id = request.CompanyId,
                CompanyId = request.AuthenticatorCompanyId
            };
            var company = await queryExecutor.Execute(query);

            if (company == null)
            {
                return new AddEmployeeResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var auth = passwordHasher.Hash(request.Password);
            request.Password = auth[0];
            request.Salt = auth[1];
            var employee = mapper.Map<Employee>(request);
            employee.Board = new Board();

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
