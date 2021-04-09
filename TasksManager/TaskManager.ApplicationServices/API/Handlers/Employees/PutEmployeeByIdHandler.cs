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
using TaskManager.DataAccess.CQRS.Queries.Employees;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Employees
{
    public class PutEmployeeByIdHandler : IRequestHandler<PutEmployeeByIdRequest, PutEmployeeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutEmployeeByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<PutEmployeeByIdResponse> Handle(PutEmployeeByIdRequest request, CancellationToken cancellationToken)
        {                  
            var query = new GetEmployeeQuery()
            {
                Id = request.Id,
                CompanyId = request.AuthenticatorCompanyId                
            };

            var query2 = new GetCompanyQuery()
            {
                Id = request.CompanyId,
                CompanyId = request.AuthenticatorCompanyId                
            };

            var employee = await queryExecutor.Execute(query);
            var company = await queryExecutor.Execute(query2);

            if (request.Login == null || request.Password == null)
            {
                request.Login = employee.Login;
                request.Password = employee.Password;
                request.Salt = employee.Salt;
            }

            if (employee == null || company == null)
            {
                return new PutEmployeeByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var updateEmployee = mapper.Map<Employee>(request);
            var command = new PutEmployeeCommand
            {
                Parameter = updateEmployee
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
