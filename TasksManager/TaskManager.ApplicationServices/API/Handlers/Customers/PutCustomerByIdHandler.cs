using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Customers;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Customers;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Customers
{
    class PutCustomerByIdHandler : IRequestHandler<PutCustomerByIdRequest, PutCustomerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public PutCustomerByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<PutCustomerByIdResponse> Handle(PutCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            var customer = mapper.Map<Customer>(request);
            var command = new PutCustomerCommand
            {
                Parameter = customer
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
