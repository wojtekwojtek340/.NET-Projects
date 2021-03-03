using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Customers;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Customers;

namespace TaskManager.ApplicationServices.API.Handlers.Customers
{
    public class DeleteCustomerByIdHandler : IRequestHandler<DeleteCustomerByIdRequest, DeleteCustomerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteCustomerByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteCustomerByIdResponse> Handle(DeleteCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteCustomerCommand() { Parameter = request.CustomerId };
            var deletedCustomer = await commandExecutor.Execute(command);
            return new DeleteCustomerByIdResponse
            {
                Data = deletedCustomer
            };
        }
    }
}
