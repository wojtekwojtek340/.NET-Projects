using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Customers;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries.Customers;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Customers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersRequest, GetAllCustomersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllCustomersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllCustomersResponse> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCustomersQuery()
            {
                CompanyId = request.AuthenticatorCompanyId         
            };
            var customers = await queryExecutor.Execute(query);
            var mappedCustomers = mapper.Map<List<CustomerDto>>(customers);
            return new GetAllCustomersResponse()
            {
                Data = mappedCustomers
            };
        }
    }
}
