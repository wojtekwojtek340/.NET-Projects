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
using TaskManager.DataAccess;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries.Employees;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Employees
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployesRequest, GetAllEmployesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetAllEmployeesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllEmployesResponse> Handle(GetAllEmployesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEmployeesQuery();
            var employes = await queryExecutor.Execute(query);
            var mappedEmployes = mapper.Map<List<EmployesDto>>(employes);        
            var response = new GetAllEmployesResponse()
            {
                Data = mappedEmployes
            };
            return response;           
        }
    }
}
