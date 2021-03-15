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
using TaskManager.DataAccess.CQRS.Queries.Employees;

namespace TaskManager.ApplicationServices.API.Handlers.Employees
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdRequest, GetEmployeeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetEmployeeByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEmployeeQuery()
            {
                Id = request.EmployeeId
            };
            var employee = await queryExecutor.Execute(query);

            if(employee == null)
            {
                return new GetEmployeeByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedEmployee = mapper.Map<EmployeeDto>(employee);
            return new GetEmployeeByIdResponse
            {
                Data = mappedEmployee
            };
        }
    }
}
