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
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Customers;
using TaskManager.DataAccess.CQRS.Queries.Customers;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Customers
{
    class PutCustomerByIdHandler : IRequestHandler<PutCustomerByIdRequest, PutCustomerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutCustomerByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<PutCustomerByIdResponse> Handle(PutCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticatorRole == AppRole.Employee)
            {
                return new PutCustomerByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetCustomerQuery()
            {
                Id = request.Id,
                CompanyId = request.AuthenticatorCompanyId
            };
            var customer = await queryExecutor.Execute(query);
            if (customer == null)
            {
                return new PutCustomerByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var updateCustomer = mapper.Map<Customer>(request);
            updateCustomer.CompanyId = request.AuthenticatorCompanyId;

            var command = new PutCustomerCommand
            {
                Parameter = updateCustomer
            };
            var updatedCustome = await commandExecutor.Execute(command);
            var response = mapper.Map<CustomerDto>(updatedCustome);

            return new PutCustomerByIdResponse
            {
                Data = response
            };
        }
    }
}
