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
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Customers;
using TaskManager.DataAccess.CQRS.Queries.Customers;

namespace TaskManager.ApplicationServices.API.Handlers.Customers
{
    public class DeleteCustomerByIdHandler : IRequestHandler<DeleteCustomerByIdRequest, DeleteCustomerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteCustomerByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteCustomerByIdResponse> Handle(DeleteCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticatorRole == AppRole.Employee)
            {
                return new DeleteCustomerByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetCustomerQuery()
            {
                Id = request.CustomerId
            };
            var customer = await queryExecutor.Execute(query);
            if (customer == null)
            {
                return new DeleteCustomerByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteCustomerCommand() { Parameter = customer };
            var deletedCustomer = await commandExecutor.Execute(command);
            return new DeleteCustomerByIdResponse
            {
                Data = deletedCustomer
            };
        }
    }
}
